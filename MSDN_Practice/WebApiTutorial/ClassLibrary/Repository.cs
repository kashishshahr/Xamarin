using System;
using Newtonsoft.Json;

namespace ClassLibrary
{
    public class Repository
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("desciption")]
        public string Description { get; set; }
        [JsonProperty("html_url")]
        public Uri GitHubHomeUrl { get; set; }

        [JsonProperty("homepage")]
        public Uri HomePage { get; set; }

        [JsonProperty("watchers")]
        public int Watchers { get; set; }

    }
}
