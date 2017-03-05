using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryTool.Models
{
    public class Ssupplier
    {
        [Key]
        public int SupplierID { get; set; }
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        [Display(Name = "ZIP Code")]
        public int ZIPCode { get; set; }
        [Display(Name = "Affiliate Store")]
        public string Affiliatestore { get; set; }
        [Display(Name = "Supplier Rate")]
        public decimal SupplierRate { get; set; }
        public string Class { get; set; }
        public string Franchise { get; set; }
        [Display(Name = "Telephone/fax/email")]
        public string Telephonefaxemail { get; set; }
        [Display(Name = "Contact Name")]
        public string ContactName  { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public decimal Rating { get; set; }
        [Display(Name = "Last WA Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LastWAdate { get; set; }

    }
}