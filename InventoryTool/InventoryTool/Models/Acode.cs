using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryTool.Models
{
    public class Acode
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Code")]
        public int code { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}