using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DPY2.WebAdmin.Models.EntityModels
{
    public class Skill
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }

        public int BlockId { get; set; }
        [JsonProperty("block")]
        public virtual Block Block { get; set; }
    }
}