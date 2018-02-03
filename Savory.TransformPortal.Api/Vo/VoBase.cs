using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savory.TransformPortal.Api.Vo
{
    public abstract class VoBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("dataStatus")]
        public int DataStatus { get; set; }

        [JsonProperty("createUser")]
        public string CreateUser { get; set; }

        [JsonProperty("lastUpdateUser")]
        public string LastUpdateUser { get; set; }

        [JsonProperty("createTime")]
        public DateTime CreateTime { get; set; }

        [JsonProperty("lastUpdateTime")]
        public DateTime LastUpdateTime { get; set; }
    }
}
