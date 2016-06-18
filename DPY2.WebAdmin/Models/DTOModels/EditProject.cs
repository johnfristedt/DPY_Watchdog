using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DPY2.WebAdmin.Models.DTOModels
{
    public class EditProject
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string ImageFileName { get; set; }
    }
}