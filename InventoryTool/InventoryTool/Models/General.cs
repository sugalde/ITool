using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryTool.Models
{
    public class General
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
        [Display(Name = "Request Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Requested By")]
        public string CreatedBy { get; set; }
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
        [Display(Name = "Maintenance Comments")]
        public string MaintenanceComments { get; set; }
        [Display(Name = "AP Comments")]
        public string ApComments { get; set; }
    }
}