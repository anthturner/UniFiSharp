# Orchestrator

In order to make this system more developer-friendly, it also ships with an orchestration overlay that wraps the `UniFiApi` object and associates common information to their devices, as well as attempting to converge a basic topology based on the device objects.

Using this module allows you to observe your UniFi network as a hierarchy, inferring relationships between devices and their children and/or client devices.

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