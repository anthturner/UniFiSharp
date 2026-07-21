# Live-device integration tests

This project exercises UniFiSharp's authentication and read-only API methods against a real
UniFi controller. It is intended as an opt-in integration suite; it does not run against a
device during an ordinary credential-free `dotnet test` invocation.

## Prerequisites

- PowerShell 7 or Windows PowerShell 5.1.
- A .NET 8 SDK or newer available through the `dotnet` command.
- Network access to the UniFi controller.
- A local UniFi account with permission to read the site being tested. Cloud-only accounts and
  accounts requiring two-factor authentication are not supported by the current runner.
- The controller IP address or URL, username, password, and site name. The site name is usually
  `default` and is not necessarily the display name shown in the UniFi interface.

## Running the tests

Open PowerShell, change to the repository root (the directory containing `test-device.ps1`),
and run:

```powershell
.\test-device.ps1
```

The script prompts for:

1. The controller IP address or URL. An IP such as `192.168.1.1` is accepted and is converted
   to `https://192.168.1.1/`. You can also enter a complete URL, including a nonstandard port,
   such as `https://192.168.1.10:8443/`.
2. The controller username.
3. The controller password. PowerShell masks the password while it is entered.

The default invocation connects through the modern UniFi OS API and tests the `default` site.
To select another site, pass its internal site name:

```powershell
.\test-device.ps1 -Site mysite
```

For an older standalone UniFi Network Controller that uses the legacy API rather than the
UniFi OS proxy API, add `-LegacyApi`:

```powershell
.\test-device.ps1 -LegacyApi
```

The options can be combined:

```powershell
.\test-device.ps1 -Site mysite -LegacyApi
```

## Reversible write tests

A second, explicitly opted-in tier exercises low-impact commands that can be immediately
reversed. Enable it with:

```powershell
.\test-device.ps1 -ReversibleWrites
```

Or enable it for a non-interactive run in the settings file:

```json
"reversibleWrites": true
```

This tier creates uniquely named temporary objects and removes them in `finally` blocks. It
currently covers:

- Creating and deleting a user group.
- Creating and deleting an unassigned WLAN group.
- Creating and deleting a one-minute hotspot voucher.
- Creating and deleting a TCP port-forward rule on an unused dynamic/private port. The rule
  accepts traffic only from the documentation-only address `203.0.113.1` and forwards it to
  the documentation-only address `192.0.2.1`, making real traffic extremely unlikely.
- Enabling Locate on one adopted device and immediately disabling it in a `finally` block.
- Disabling the site LED setting and re-enabling it in a `finally` block. The API cannot read
  the previous value, so this test deliberately leaves the site setting enabled.
- Setting one adopted device's LED override to off and restoring its exact prior value.

The tier deliberately excludes client authorization/block/reconnect, connectivity-related
device configuration, port power cycling, restart, adoption, forgetting, RF scans, firmware
upgrades, media uploads, and stream operations. A process termination or controller outage
between creation and cleanup can still leave a temporary object behind. Such objects have a
name beginning with `unifisharp-it-` so they can be found and removed manually.

Every reversal failure is caught and recorded instead of being lost among individual test
output. After the entire collection finishes, teardown emits one explicit
`REVERSIBLE-WRITE CLEANUP FAILED. MANUAL ACTION IS REQUIRED` failure containing each resource,
its ID or device MAC where available, the reversal error, and exact manual remediation. This
ensures all tests get a chance to run while still making an incomplete cleanup fail the suite.

## Running non-interactively from a settings file

For an automated or LLM-driven run, copy the committed template to the ignored local settings
filename:

```powershell
Copy-Item .\UniFiSharp.DeviceTests\device-test-settings.json.example `
    .\UniFiSharp.DeviceTests\device-test-settings.json
```

Edit `UniFiSharp.DeviceTests\device-test-settings.json` and replace the example values:

```json
{
  "url": "https://192.168.1.1/",
  "username": "integration-test-user",
  "password": "replace-with-password",
  "site": "default",
  "modernApi": true,
  "reversibleWrites": false
}
```

Then run the suite without prompts:

```powershell
.\test-device.ps1 -ConfigFile .\UniFiSharp.DeviceTests\device-test-settings.json
```

The `url`, `username`, and `password` properties are required. `site` defaults to `default`,
and `modernApi` defaults to `true` when omitted. `reversibleWrites` defaults to `false`.
Command-line `-Site`, `-LegacyApi`, and `-ReversibleWrites` options override the corresponding
file values.

The `.gitignore` explicitly excludes `UniFiSharp.DeviceTests/device-test-settings*.json` while
leaving the `.json.example` template tracked. Confirm that the real file is ignored before
adding repository changes:

```powershell
git check-ignore .\UniFiSharp.DeviceTests\device-test-settings.json
```

The settings file contains a plaintext password. Keep it only on a trusted machine, restrict
its filesystem permissions, and delete it when unattended access is no longer needed. Once
you have created the ignored file, an LLM agent working in this repository can run the exact
`-ConfigFile` command above without receiving the password in chat or command-line arguments.

If local PowerShell policy prevents scripts from running, this runs the script with a
process-scoped policy override without changing the machine policy:

```powershell
powershell -ExecutionPolicy Bypass -File .\test-device.ps1
```

## Results

The script restores and builds the test project if necessary, authenticates once, runs the
live tests sequentially, and logs out when the suite finishes. A successful run ends with a
summary similar to:

```text
Passed! - Failed: 0, Passed: 25, Skipped: 0, Total: 25
```

List operations are valid when they return an empty collection. Tests for an individual
client, user, device, media file, voucher, or broadcast group first obtain an existing item
from the corresponding list. If that type of item does not exist, the test reports the lookup
as not applicable instead of manufacturing data on the controller.

The process exit code is the `dotnet test` exit code, so `0` means the run succeeded and a
nonzero value means the build or at least one test failed.

## Safety and credentials

The suite covers authentication and read behavior only. It does not create, update, delete,
restart, reconnect, adopt, forget, scan, upload, or stream anything. The RF scan status test
only reads existing status; it does not start an RF scan.

Self-signed TLS certificates are accepted because they are common on local controllers. The
password is placed temporarily in environment variables inherited by the test process and is
removed from the runner process in a `finally` block after `dotnet test` exits. Interactive
credentials are not saved. A settings file is plaintext by design and must remain ignored and
local as described above.

## Running with environment variables

The PowerShell runner is the recommended entry point. For automation, the test project can be
run directly after defining the same process environment variables:

```powershell
$env:UNIFI_DEVICE_URL = "https://192.168.1.1/"
$env:UNIFI_DEVICE_USERNAME = "integration-test-user"
$env:UNIFI_DEVICE_PASSWORD = "password"
$env:UNIFI_DEVICE_SITE = "default"
$env:UNIFI_DEVICE_MODERN_API = "true"
$env:UNIFI_DEVICE_REVERSIBLE_WRITES = "false"
dotnet test .\UniFiSharp.DeviceTests\UniFiSharp.DeviceTests.csproj
```

`UNIFI_DEVICE_URL`, `UNIFI_DEVICE_USERNAME`, and `UNIFI_DEVICE_PASSWORD` are required.
`UNIFI_DEVICE_SITE` defaults to `default`, and `UNIFI_DEVICE_MODERN_API` defaults to `true`.
Set the latter to `false` for the legacy API. Remove manually assigned variables after the run:

```powershell
Remove-Item Env:UNIFI_DEVICE_URL, Env:UNIFI_DEVICE_USERNAME, Env:UNIFI_DEVICE_PASSWORD,
    Env:UNIFI_DEVICE_SITE, Env:UNIFI_DEVICE_MODERN_API,
    Env:UNIFI_DEVICE_REVERSIBLE_WRITES -ErrorAction SilentlyContinue
```

Without the three required variables, all live-device tests are discovered but skipped. This
makes `dotnet test UniFiSharp.sln` safe to run as a normal build or CI check.

## Troubleshooting

- **Connection refused or timed out:** Confirm the controller address, HTTPS port, and network
  route. Older standalone controllers commonly use a URL such as `https://host:8443/`.
- **Unauthorized:** Confirm the local username and password and that the account can access the
  selected site. The runner does not currently prompt for a two-factor authentication code.
- **Not found through `proxy/network`:** The target probably uses the standalone legacy API;
  retry with `-LegacyApi`.
- **Endpoints fail on older or specialized controllers:** Some features, including hotspot,
  media, broadcast, and streaming endpoints, may not be supported by every controller version
  or hardware configuration. These failures are retained as test failures so incompatibilities
  remain visible.
