using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryTool.Models
{
    public class CR
    {
        [Key]
        public int crID { get; set; }
        [Display(Name = "WA number")]
        public string WAnumber { get; set; }
        [Display(Name = "VIN number")]
        public string VINnumber { get; set; }
        [Display(Name = "Service Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Servicedate { get; set; }
        public int Odometer { get; set; }
        public string Status { get; set; }
        public int Supplier { get; set; }
        [Display(Name = "Supplier Name")]
        public string Suppliername { get; set; }
        [Display(Name = "Client Name")]
        public string Clientname { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,###0.00}")]
        public decimal Subtotal { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,###0.00}")]
        public decimal IVA { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,###0.00}")]
        public decimal Total { get; set; }
        [Display(Name = "Oked By")]
        public string OkedBy { get; set; }
        [Display(Name = "Invoice Number")]
        public string Invoicenumber { get; set; }
        [Display(Name = "Service Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Invoicedate { get; set; }
        [Display(Name = "Amount Paid")]
        [DisplayFormat(DataFormatString = "{0:#,###0.00}")]
        public double Amountpaid { get; set; }
        [Display(Name = "Payment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Paymentdate { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Maintenance Comments")]
        public string MaintenanceComments { get; set; }
        [Display(Name = "AP Comments")]
        public string ApComments { get; set; }


    }
}