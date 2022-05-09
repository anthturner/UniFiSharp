using Newtonsoft.Json;
using System.ComponentModel;
using UniFiSharp.Json.Attributes;

namespace UniFiSharp.Json
{
    /// <summary>
    /// Payment transaction details
    /// </summary>
    [DisplayName("Transaction Details")]
    public class JsonPaymentTransactionInformation
    {
        // TODO
        [JsonProperty("package")]
        public string _package { get; set; }

        /// <summary>
        /// Transaction amount
        /// </summary>
        [DisplayName("Amount")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("amount")]
        public string amount { get; set; }

        /// <summary>
        /// Payment card type
        /// </summary>
        [DisplayName("Card Type")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("cardtype")]
        public string cardtype { get; set; }

        /// <summary>
        /// Billing address city
        /// </summary>
        [DisplayName("City")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("city")]
        public string city { get; set; }

        /// <summary>
        /// Currency used for payment
        /// </summary>
        [DisplayName("Currency")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("currency")]
        public string currency { get; set; }

        /// <summary>
        /// Date/time of transaction
        /// </summary>
        [DisplayName("Date/Time of Transaction")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("datetime")]
        public string datetime { get; set; }

        /// <summary>
        /// First name of purchaser
        /// </summary>
        [DisplayName("First Name")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("first_name")]
        public string firstName { get; set; }

        /// <summary>
        /// Gateway used to process transaction
        /// </summary>
        [DisplayName("Transaction Gateway")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("gateway")]
        public string gateway { get; set; }

        /// <summary>
        /// Payment Transaction ID
        /// </summary>
        [DisplayName("Payment Transaction ID")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("_id")]
        public string id { get; set; }

        // TODO
        [JsonProperty("info")]
        public string info { get; set; }

        /// <summary>
        /// Last name of purchaser
        /// </summary>
        [DisplayName("Last Name")]
        [ShowWith(Levels.Basic)]
        [JsonProperty("last_name")]
        public string lastName { get; set; }

        /// <summary>
        /// Transaction Name
        /// </summary>
        [DisplayName("Transaction Name")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
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
        [ShowWith(Levels.Basic)]
        [JsonProperty("zip")]
        public string zip { get; set; }
    }
}
