using Newtonsoft.Json;

namespace UniFiSharp.Json
{
    public class JsonPaymentTransactionInformation
    {
        [JsonProperty("package")]
        public string _package { get; set; }

        [JsonProperty("amount")]
        public string amount { get; set; }

        [JsonProperty("cardtype")]
        public string cardtype { get; set; }

        [JsonProperty("city")]
        public string city { get; set; }

        [JsonProperty("currency")]
        public string currency { get; set; }

        [JsonProperty("datetime")]
        public string datetime { get; set; }

        [JsonProperty("first_name")]
        public string firstName { get; set; }

        [JsonProperty("gateway")]
        public string gateway { get; set; }

        [JsonProperty("_id")]
        public string id { get; set; }

        [JsonProperty("info")]
        public string info { get; set; }

        [JsonProperty("last_name")]
        public string lastName { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("site_id")]
        public string siteId { get; set; }

        [JsonProperty("state")]
        public string state { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("time")]
        public long time { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("x_transaction_id")]
        public string xTransactionId { get; set; }

        [JsonProperty("zip")]
        public string zip { get; set; }
    }
}
