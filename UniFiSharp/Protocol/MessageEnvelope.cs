using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UniFiSharp.Protocol
{
    public class MessageEnvelope
    {
        [JsonProperty(PropertyName = "meta")]
        public MessageMetadata Metadata { get; set; }

        public bool IsSuccessfulResponse { get { return Metadata != null && Metadata.ResultCode.Equals("ok", StringComparison.OrdinalIgnoreCase); } }
    }

    public class MessageEnvelope<T> : MessageEnvelope where T : IMessageBase
    {
        [JsonProperty(PropertyName = "data")]
        public List<T> Data { get; set; }
    }

    public interface IMessageBase { }

    public class BlankMessage : IMessageBase { }

    public class MessageMetadata
    {
        [JsonProperty(PropertyName = "msg")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "rc")]
        public string ResultCode { get; set; }
    }
}