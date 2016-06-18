using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DPY2.WebAdmin.Models.EntityModels
{
    [JsonObject]
    public class Page
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("blocks")]
        public virtual List<Block> Blocks { get; set; }
    }
}