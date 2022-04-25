using UniFiSharp.Json;

namespace UniFiSharp.CLI
{
    public static class OutputMaps
    {

        public static OutputMapping<JsonNetworkDevice>[] NetworkDevice => new[]
        {
            OutputMapping<JsonNetworkDevice>.Create("Adopted", d => d.adopted),
            OutputMapping<JsonNetworkDevice>.Create("Type", d => d.type),
            OutputMapping<JsonNetworkDevice>.Create("ID", d => d.device_id),
            OutputMapping<JsonNetworkDevice>.Create("Name", d => d.name),
            OutputMapping<JsonNetworkDevice>.Create("IP Address", d => d.ip)
        };

        public static OutputMapping<JsonSpectrumTable>[] SpectrumScan => new[]
        {
            OutputMapping<JsonSpectrumTable>.Create("Channel", s => s.channel),
            OutputMapping<JsonSpectrumTable>.Create("Samples", s => s.total_samples),
            OutputMapping<JsonSpectrumTable>.Create("Width", s => s.width),
            OutputMapping<JsonSpectrumTable>.Create("Utilization", s => s.utilization)
        };

        public static OutputMapping<JsonBroadcastGroup>[] BroadcastGroup => new[]
        {
            OutputMapping<JsonBroadcastGroup>.Create("ID", bg => bg._id),
            OutputMapping<JsonBroadcastGroup>.Create("Name", bg => bg.name)
        };

        public static OutputMapping<JsonClient>[] Client => new[]
        {
            OutputMapping<JsonClient>.Create("MAC Address", c => c.mac),
            OutputMapping<JsonClient>.Create("Name", c => c.name),
            OutputMapping<JsonClient>.Create("Network", c => c.network),
            OutputMapping<JsonClient>.Create("BSSID", c => c.bssid),
            OutputMapping<JsonClient>.Create("IP", c => c.ip),
            OutputMapping<JsonClient>.Create("Signal", c => c.signal)
        };

        public static OutputMapping<JsonGuest>[] HotspotGuests => new[]
        {
            OutputMapping<JsonGuest>.Create("MAC Address", c => c.mac),
            OutputMapping<JsonGuest>.Create("Name", c => c.name),
            OutputMapping<JsonGuest>.Create("IP", c => c.ip),
            OutputMapping<JsonGuest>.Create("Voucher ID", c => c.voucherId)
        };

        public static OutputMapping<JsonPaymentTransactionInformation>[] HotspotPayments => new[]
        {
            OutputMapping<JsonPaymentTransactionInformation>.Create("TX ID", p => p.xTransactionId),
            OutputMapping<JsonPaymentTransactionInformation>.Create("Amount", p => p.amount),
            OutputMapping<JsonPaymentTransactionInformation>.Create("Info", p => p.info),
            OutputMapping<JsonPaymentTransactionInformation>.Create("Type", p => p.type),
            OutputMapping<JsonPaymentTransactionInformation>.Create("Name", p => p.name)
        };

        public static OutputMapping<JsonHotspotOperator>[] HotspotOperators => new[]
        {
            OutputMapping<JsonHotspotOperator>.Create("ID", o => o.id),
            OutputMapping<JsonHotspotOperator>.Create("Name", o => o.name),
            OutputMapping<JsonHotspotOperator>.Create("Note", o => o.note)
        };

        public static OutputMapping<JsonHotspotVoucher>[] HotspotVouchers => new[]
        {
            OutputMapping<JsonHotspotVoucher>.Create("ID", v => v.id),
            OutputMapping<JsonHotspotVoucher>.Create("Used", v => v.used),
            OutputMapping<JsonHotspotVoucher>.Create("Quota", v => v.quota),
            OutputMapping<JsonHotspotVoucher>.Create("Duration", v => v.duration),
            OutputMapping<JsonHotspotVoucher>.Create("Status", v => v.status)
        };

        public static OutputMapping<JsonMediaFile>[] MediaFiles => new[]
        {
            OutputMapping<JsonMediaFile>.Create("Name", mf => mf.name),
            OutputMapping<JsonMediaFile>.Create("Filename", mf => mf.filename),
            OutputMapping<JsonMediaFile>.Create("Content-Type", mf => mf.content_type),
            OutputMapping<JsonMediaFile>.Create("URL", mf => mf.url)
        };

        public static OutputMapping<JsonSystemHealth>[] SystemHealth => new[]
        {
            OutputMapping<JsonSystemHealth>.Create("Adopted", sh => sh.numAdopted),
            OutputMapping<JsonSystemHealth>.Create("Disabled", sh => sh.numDisabled),
            OutputMapping<JsonSystemHealth>.Create("Drops", sh => sh.drops),
            OutputMapping<JsonSystemHealth>.Create("Speed Test Ping", sh => sh.speedtestPing),
            OutputMapping<JsonSystemHealth>.Create("Speed Test Status", sh => sh.speedtestStatus),
            OutputMapping<JsonSystemHealth>.Create("Nameservers", sh => sh.nameservers),
            OutputMapping<JsonSystemHealth>.Create("RX Bytes", sh => sh.rxBytesR),
            OutputMapping<JsonSystemHealth>.Create("TX Bytes", sh => sh.txBytesR)
        };

        public static OutputMapping<JsonSite>[] Sites => new[]
        {
            OutputMapping<JsonSite>.Create("ID", s => s._id),
            OutputMapping<JsonSite>.Create("Name", s => s.name),
            OutputMapping<JsonSite>.Create("Stations", s => s.num_sta),
            OutputMapping<JsonSite>.Create("APs", s => s.num_ap),
            OutputMapping<JsonSite>.Create("Description", s => s.desc),
        };

        public static OutputMapping<JsonRogueAp>[] RogueAps => new[]
        {
            OutputMapping<JsonRogueAp>.Create("MAC Address", rap => rap.apMac),
            OutputMapping<JsonRogueAp>.Create("RSSI", rap => rap.rssi),
            OutputMapping<JsonRogueAp>.Create("Age", rap => rap.age),
            OutputMapping<JsonRogueAp>.Create("Channel", rap => rap.channel),
            OutputMapping<JsonRogueAp>.Create("BSSID", rap => rap.bssid),
            OutputMapping<JsonRogueAp>.Create("Model", rap => rap.modelDisplay)
        };

        public static OutputMapping<JsonPortForward>[] PortForwards => new[]
        {
            OutputMapping<JsonPortForward>.Create("ID", pf => pf._id),
            OutputMapping<JsonPortForward>.Create("Name", pf => pf.name),
            OutputMapping<JsonPortForward>.Create("Source", pf => pf.src + ":" + pf.fwd_port),
            OutputMapping<JsonPortForward>.Create("Destination", pf => pf.fwd + ":" + pf.dst_port)
        };

        public static OutputMapping<JsonUserGroup>[] UserGroups => new[]
        {
            OutputMapping<JsonUserGroup>.Create("ID", ug => ug._id),
            OutputMapping<JsonUserGroup>.Create("Name", ug => ug.name),
            OutputMapping<JsonUserGroup>.Create("Max Up", ug => ug.qos_rate_max_up),
            OutputMapping<JsonUserGroup>.Create("Max Down", ug => ug.qos_rate_max_down)
        };

        public static OutputMapping<JsonWlanGroup>[] WlanGroups => new[]
        {
            OutputMapping<JsonWlanGroup>.Create("ID", ug => ug._id),
            OutputMapping<JsonWlanGroup>.Create("Name", ug => ug.name),
            OutputMapping<JsonWlanGroup>.Create("Roam 5G", ug => ug.roam_channel_na.GetValueOrDefault()),
            OutputMapping<JsonWlanGroup>.Create("Roam 2.4G", ug => ug.roam_channel_ng.GetValueOrDefault()),
            OutputMapping<JsonWlanGroup>.Create("Radio", ug => ug.roam_radio)
        };

        public static OutputMapping<JsonUser>[] Users => new[]
        {
            OutputMapping<JsonUser>.Create("ID", ug => ug._id),
            OutputMapping<JsonUser>.Create("MAC Address", ug => ug.mac),
            OutputMapping<JsonUser>.Create("Name", ug => ug.name),
            OutputMapping<JsonUser>.Create("Guest", ug => ug.is_guest),
            OutputMapping<JsonUser>.Create("TX Bytes", ug => ug.tx_bytes),
            OutputMapping<JsonUser>.Create("RX Bytes", ug => ug.rx_bytes),
        };
    }
}
