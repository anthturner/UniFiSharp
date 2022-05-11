using Newtonsoft.Json;
using System.ComponentModel;
using UniFiSharp.Json.Attributes;

namespace UniFiSharp.Json
{
    /// <summary>
    /// Information around currently authenticated user
    /// </summary>
    [DisplayName("Current User")]
    public class JsonLoginResult : IJsonObject
    {
        /// <summary>
        /// User's First Name
        /// </summary>
        [DisplayName("First Name")]
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// User's Last Name
        /// </summary>
        [DisplayName("Last Name")]
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// User's Full Name
        /// </summary>
        [DisplayName("Full Name")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        /// <summary>
        /// User's email address
        /// </summary>
        [DisplayName("EMail Address")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("email")]
        public string Email { get; set; }

        // TODO
        [JsonProperty("email_status")]
        public string EmailStatus { get; set; }

        // TODO
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Username of logged in user
        /// </summary>
        [DisplayName("Username")]
        [Identifier]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// If the account is local or remote (SSO)
        /// </summary>
        [DisplayName("Local Account?")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("local_account_exist")]
        public bool HasLocalAccount { get; set; }

        /// <summary>
        /// SSO account name mapping
        /// </summary>
        [DisplayName("SSO Account")]
        [ShowWith(Levels.Extended)]
        [JsonProperty("sso_account")]
        public string SsoAccount { get; set; }

        /// <summary>
        /// If the user is an owner
        /// </summary>
        [DisplayName("Owner?")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("isOwner")]
        public bool IsOwner { get; set; }

        /// <summary>
        /// If the user is a super admin
        /// </summary>
        [DisplayName("Super Admin?")]
        [ShowWith(Levels.Minimal)]
        [JsonProperty("isSuperAdmin")]
        public bool IsSuperAdmin { get; set; }
    }
}
