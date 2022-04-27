# Example Usage
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