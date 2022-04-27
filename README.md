<img src="https://github.com/anthturner/UniFiSharp/blob/master/UniFiSharp/UniFiSharpLogo.png?raw=true" width="150px" title="UniFiSharp Logo" />

# UniFiSharp

_Bringing Ubiquiti UniFi Orchestration Automation to C#_

UniFiSharp provides a basic C# API for Ubiquiti UniFi controllers, as well as an orchestration overlay to more easily visualize network topology and execute device commands. UniFiSharp also implements both v1 and v2 of the Ubiquiti discovery protocol for automated controller discovery.

**As of UniFiSharp v1.1.0, the API surface has changed slightly to improve usability and maintainability; please read the usage documentation below.**

This project is written for any .NET application that can consume a .NET Standard 2.0 library. All future contributions are planned to continue to enable cross-platform use.

### Basic API Usage
The `UniFiApi` class provides all base-level API features:

```csharp
// Instantiate the API object
using (var api = new UniFiSharp.UniFiApi(new Uri("https://controller:8443"), "username", "password", "siteName"))
{
    // Manually calling .Authenticate() forces the API to proactively authenticate.
    // Otherwise, the request will be automatically authenticated upon receiving an unauthorized error.
    await api.Authenticate();

    // ... for example, enumerate all UniFi devices known by the controller:
    IEnumerable<UniFiSharp.Json.JsonNetworkDevice> uniFiDevices = await api.NetworkDeviceList();

    // ... or to upgrade the firmware on a device:
    await api.NetworkDeviceUpgrade("01:23:45:67:89:AB");
}
```

### Orchestration Usage
In order to make this system more developer-friendly, it also ships with an orchestration overlay that wraps the `UniFiApi` object and associates common information to their devices, as well as attempting to converge a basic topology based on the device objects:

```csharp
// Instantiate the API object
using (var api = new UniFiSharp.UniFiApi(new Uri("https://controller:8443"), "username", "password", "siteName"))
using (var orchestrator = new UniFiSharp.Orchestration.UniFiOrchestrator(api))
{    
    // Calls api.Refresh() under the hood
    await orchestrator.Refresh();
    
    // ... for example, retrieve the first AP and turn on its locator for 5 seconds:
    await orchestrator.InfrastructureDevices.First(d => d is UniFiSharp.Orchestration.Devices.AccessPointInfrastructureNetworkedDevice).Locate(5000);
    
    // ... or to browse the network topology from the edge inwards, start from:
    INetworkedDevice networkRoot = orchestrator.TopologicalRoot;
    
    // ... or to create a new port forward (to 192.168.1.100:TCP/80):
    await orchestrator.PortForwards.Add(
              UniFiSharp.Orchestration.Models.PortForward.Create(
                  name: "abc",
                  proto: "tcp",
                  source: "any",
                  sourcePort: 80,
                  dest: "192.168.1.100",
                  destPort: 80
              ));
}
```

### Disclaimer
This software is not affiliated with nor supported by Ubiquiti Networks and is offered under the license as described in `LICENSE`. This software should *never* be used in a production environment without exhaustive, independent testing.

The "U" logo component used is strictly for product identification purposes only, and is protected by fair use.
