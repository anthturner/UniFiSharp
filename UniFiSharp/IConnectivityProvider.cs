using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniFiSharp.Protocol;

namespace UniFiSharp
{
    public abstract class IConnectivityProvider
    {
        public Uri BaseUri { get; private set; }
        public TimeSpan Timeout { get; set; } = new TimeSpan(0, 1, 0);
        public bool SslCertificateValidation { get; private set; } = true;

        public abstract event EventHandler AuthenticationRequired;
        
        public abstract Task<List<TResponse>> Get<TResponse>(string relativeUri) where TResponse : IMessageBase;
        public abstract Task Delete(string relativeUri);
        public abstract Task<List<TResponse>> Post<TRequest, TResponse>(string relativeUri, TRequest data) where TResponse : IMessageBase;
        public abstract Task Put<TRequest>(string relativeUri, TRequest data);

        protected IConnectivityProvider(Uri baseUri, bool sslCertificateValidation = true)
        {
            BaseUri = baseUri;
            SslCertificateValidation = sslCertificateValidation;
        }

        protected List<TResponse> DeserializeResponseMessage<TResponse>(string json) where TResponse : IMessageBase
        {
            if (string.IsNullOrEmpty(json))
                return new List<TResponse>();

            // Deserialize to a message envelope to extract the status message on failure
            var messageEnvelope = JsonConvert.DeserializeObject<MessageEnvelope>(json);
            if (!messageEnvelope.IsSuccessfulResponse)
            {
                if (messageEnvelope.Metadata.Message.Trim() == "api.err.LoginRequired")
                    throw new UnauthorizedAccessException("Session requires authentication");
                else
                    throw new Exception(messageEnvelope.Metadata.Message);
            }

            try
            {
                var result = JsonConvert.DeserializeObject<MessageEnvelope<TResponse>>(json);
                return result.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deserialization exception:\n{ex.ToString()}");
                throw ex;
            }
        }
    }
}
