using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savory.TransformPortal.Api.Vo
{
    public class TemplateVo : VoBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("itemJsonValue")]
        public string ItemJsonValue { get; set; }
    }
}
