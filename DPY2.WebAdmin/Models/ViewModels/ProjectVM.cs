using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DPY2.WebAdmin.Models.ViewModels
{
    [JsonObject]
    public class ProjectVM
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("imageURI")]
        public string ImageURI { get; set; }
    }
}