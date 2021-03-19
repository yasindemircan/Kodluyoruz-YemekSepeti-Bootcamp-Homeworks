using System;
using Newtonsoft.Json;

namespace hotels.API.Abstract
{
    public class Resource
    {
        [JsonProperty(Order = -1)]
        public string Href { get; set; }
    }
}
