using Newtonsoft.Json;

namespace UniFiSharp.Json
{
    public class JsonPaymentTransactionInformation
    {
        [JsonProperty("package")]
        public string _package;

        [JsonProperty("amount")]
        public string amount;

        [JsonProperty("cardtype")]
        public string cardtype;

        [JsonProperty("city")]
        public string city;

        [JsonProperty("currency")]
        public string currency;

        [JsonProperty("datetime")]
        public string datetime;

        [JsonProperty("first_name")]
        public string firstName;

        [JsonProperty("gateway")]
        public string gateway;

        [JsonProperty("_id")]
        public string id;

        [JsonProperty("info")]
        public string info;

        [JsonProperty("last_name")]
        public string lastName;

        [JsonProperty("name")]
        public string name;

        [JsonProperty("site_id")]
        public string siteId;

        [JsonProperty("state")]
        public string state;

        [JsonProperty("status")]
        public string status;

        [JsonProperty("time")]
        public long time;

        [JsonProperty("type")]
        public string type;

        [JsonProperty("x_transaction_id")]
        public string xTransactionId;

        [JsonProperty("zip")]
        public string zip;
    }
}
