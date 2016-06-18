using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DPY2.WebAdmin.Models.EntityModels
{
    [JsonObject]
    public class Block
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; }

        [JsonProperty("skills")]
        public virtual List<Skill> Skills { get; set; }
        [JsonProperty("projects")]
        public virtual List<Project> Projects { get; set; }

        public int PageId { get; set; }
        [JsonProperty("page")]
        public virtual Page Page { get; set; }
    }
}