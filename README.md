# UniFiSharp

_Bringing Ubiquiti UniFi Orchestration Automation to C#_

UniFiSharp provides a basic C# API for Ubiquiti UniFi controllers, as well as an orchestration overlay to more easily visualize network topology and execute device commands. UniFiSharp also implements both v1 and v2 of the Ubiquiti discovery protocol for automated controller discovery.

This project is anchored in a .NET Core implementation, targeting a minimum of NETCoreApp1.1 and NET4.6.1. All future contributions are planned to continue to enable cross-platform usage via .NET Core.

### Basic API Usage
The `UniFiApi` class provides all base-level API features:

```csharp
# Instantiate the API object
var api = new UniFiSharp.UniFiApi(new Uri("https://controller:8443/"), "username", "password", "siteName");

# Manually calling .Authenticate() is optional -- it will be automatically called if the wrapper is not authenticated when executing a command
await api.Authenticate();

# ... for example, enumerate all UniFi devices known by the controller:
List<UniFiSharp.Protocol.NetworkDevice> uniFiDevices = await api.ListDevices();

# ... or upgrade the firmware on a device:
await api.Upgrade("01:23:45:67:89:AB");
```

### UBNT Cloud
The `UniFiApi` class can also be used with UBNT Cloud-hosted services by changing the base URI to match the UBNT Cloud format:

```csharp
# Instantiate the API object
var api = new UniFiApi(new Uri("https://demo.ubnt.com/manage"), "username", "password");

# Manually calling .Authenticate() is optional -- it will be automatically called if the wrapper is not authenticated when executing a command
await api.Authenticate();

# The below command will retrieve all devices from the UBNT cloud's demo site
List<UniFiSharp.Protocol.NetworkDevice> uniFiDevices = await api.ListDevices();
```

*Note: The above code works as-written; at the time of this writing, Ubiquiti's cloud will accept the above demo credentials and allow the user to work in a sandboxed, artificial environment. This demo setup includes approximately 130 UniFi devices and 1200 clients.*

### Orchestration Usage
In order to make this system more developer-friendly, it also ships with an orchestration overlay that wraps the `UniFiApi` object and associates common information to their devices, as well as attempting to converge a basic topology based on the device objects:

```csharp
# Instantiate the API object the same way as with basic usage
var api = new UniFiSharp.UniFiApi(new Uri("https://controller:8443/"), "username", "password", "siteName");

# Create a NetworkDeploymentSite object that wraps the API instance -- this is the base object for site orchestration
var site = new UniFiSharp.Orchestration.NetworkDeploymentSite(api);

# Refresh all parameters in the site -- this includes WLANs, Port Forwards, User/WLAN Groups, etc.
await site.Refresh();

# ... for example, create a wireless network with a given User Group and WLAN Group:
await site.WirelessNetworks.Add("SSID1", "WlanKey", site.UserGroups.First(), site.WirelessNetworkGroups.First());

# ... or add a port forward to 192.168.1.100/TCP(80), if you're using a UniFi Security Gateway:
await site.PortForwards.Add("Port Forward Example", "tcp", "any", "192.168.1.100", 80, 80);
```

### Disclaimer
This software is not affiliated with nor supported by Ubiquiti Networks and is offered under the license as described in `LICENSE`. This software should *never* be used in a production environment without exhaustive, independent testing.
