using Newtonsoft.Json;
using System.ComponentModel;

namespace UniFiSharp.Json
{
    public class JsonPaymentTransactionInformation
    {
        // TODO
        [JsonProperty("package")]
        public string _package { get; set; }

        /// <summary>
        /// Transaction amount
        /// </summary>
        [DisplayName("Amount")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("amount")]
        public string amount { get; set; }

        /// <summary>
        /// Payment card type
        /// </summary>
        [DisplayName("Card Type")]
        [Complexity(Complexities.Average)]
        [JsonProperty("cardtype")]
        public string cardtype { get; set; }

        /// <summary>
        /// Billing address city
        /// </summary>
        [DisplayName("City")]
        [Complexity(Complexities.Average)]
        [JsonProperty("city")]
        public string city { get; set; }

        /// <summary>
        /// Currency used for payment
        /// </summary>
        [DisplayName("Currency")]
        [Complexity(Complexities.Average)]
        [JsonProperty("currency")]
        public string currency { get; set; }

        /// <summary>
        /// Date/time of transaction
        /// </summary>
        [DisplayName("Date/Time of Transaction")]
        [Complexity(Complexities.Average)]
        [JsonProperty("datetime")]
        public string datetime { get; set; }

        /// <summary>
        /// First name of purchaser
        /// </summary>
        [DisplayName("First Name")]
        [Complexity(Complexities.Average)]
        [JsonProperty("first_name")]
        public string firstName { get; set; }

        /// <summary>
        /// Gateway used to process transaction
        /// </summary>
        [DisplayName("Transaction Gateway")]
        [Complexity(Complexities.Average)]
        [JsonProperty("gateway")]
        public string gateway { get; set; }

        /// <summary>
        /// Payment Transaction ID
        /// </summary>
        [DisplayName("Payment Transaction ID")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("_id")]
        public string id { get; set; }

        // TODO
        [JsonProperty("info")]
        public string info { get; set; }

        /// <summary>
        /// Last name of purchaser
        /// </summary>
        [DisplayName("Last Name")]
        [Complexity(Complexities.Average)]
        [JsonProperty("last_name")]
        public string lastName { get; set; }

        /// <summary>
        /// Transaction Name
        /// </summary>
        [DisplayName("Transaction Name")]
        [IncludeInObjectGroup]
        [Complexity(Complexities.Low)]
        [JsonProperty("name")]
        public string name { get; set; }

        /// <summary>
        /// Site ID which tracks/manages the payment transaction
        /// </summary>
        [DisplayName("Site ID")]
        [JsonProperty("site_id")]
        public string siteId { get; set; }

        // TODO
        [JsonProperty("state")]
        public string state { get; set; }

        // TODO
        [JsonProperty("status")]
        public string status { get; set; }

        // TODO
        [JsonProperty("time")]
        public long time { get; set; }

        // TODO
        [JsonProperty("type")]
        public string type { get; set; }

        // TODO
        [JsonProperty("x_transaction_id")]
        public string xTransactionId { get; set; }

        /// <summary>
        /// Billing Address ZIP Code
        /// </summary>
        [DisplayName("ZIP Code")]
        [JsonProperty("zip")]
        public string zip { get; set; }
    }
}
