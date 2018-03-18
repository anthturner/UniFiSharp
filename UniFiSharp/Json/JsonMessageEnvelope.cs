using Newtonsoft.Json;
using System;

namespace UniFiSharp.Json
{
    public class JsonMessageEnvelope
    {
        [JsonProperty(PropertyName = "meta")]
        public JsonMessageEnvelopeMetadata Metadata { get; set; }
        public bool IsSuccessfulResponse { get { return Metadata != null && Metadata.ResultCode.Equals("ok", StringComparison.OrdinalIgnoreCase); } }

        public class JsonMessageEnvelopeMetadata
        {
            [JsonProperty(PropertyName = "msg")]
            public string Message { get; set; }

            [JsonProperty(PropertyName = "rc")]
            public string ResultCode { get; set; }
        }
    }

    public class JsonMessageEnvelope<T> : JsonMessageEnvelope where T : new()
    {
        [JsonProperty(PropertyName = "data")]
        public T[] Data { get; set; }
    }
}
