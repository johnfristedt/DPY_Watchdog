using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DPY2.WebAdmin.Models.EntityModels
{
    [JsonObject]
    public class Project
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("imageFileName")]
        public string ImageFileName { get; set; }

        public int BlockId { get; set; }
        [JsonProperty("block")]
        public virtual Block Block { get; set; }

        [JsonProperty("imageURI")]
        [NotMapped]
        public string ImageURI
        {
            get
            {
                return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/Uploads/Images/" + ImageFileName;
            }
        }
    }
}