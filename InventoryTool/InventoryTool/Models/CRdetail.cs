using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryTool.Models
{
    public class CRdetail
    {
        [Key]
        public int ID { get; set; }
        public int IDCR { get; set; }
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "ATA code")]
        public int Atacode { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Amount Requested")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:#,###0.00}")]
        public decimal Requested { get; set; }
        [Display(Name = "Amount Authorized")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:#,###0.00}")]
        public decimal Authorized { get; set; }
        [Display(Name = "Create Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
    }
}