using Newtonsoft.Json;

namespace UniFiSharp.Json
{
    public class JsonSampleMedia
    {
        [JsonProperty("sample_filename")]
        public string sample_filename { get; set; }
    }
}
