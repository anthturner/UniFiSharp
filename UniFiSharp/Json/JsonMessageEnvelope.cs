using Newtonsoft.Json;
using System;

namespace UniFiSharp.Json
{
    internal class JsonMessageEnvelope
    {
        [JsonProperty(PropertyName = "meta")]
        public JsonMessageEnvelopeMetadata Metadata { get; set; }
        public bool IsSuccessfulResponse { get { return Metadata != null && Metadata.ResultCode.Equals("ok", StringComparison.OrdinalIgnoreCase); } }

        internal class JsonMessageEnvelopeMetadata
        {
            [JsonProperty(PropertyName = "msg")]
            public string Message { get; set; }

            [JsonProperty(PropertyName = "rc")]
            public string ResultCode { get; set; }
        }
    }

    internal class JsonMessageEnvelope<T> : JsonMessageEnvelope where T : new()
    {
        [JsonProperty(PropertyName = "data")]
        public T[] Data { get; set; }
    }
}
