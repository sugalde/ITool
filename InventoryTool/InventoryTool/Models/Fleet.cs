using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryTool.Models
{
    public class Fleet
    {
        [Key]
        public int FleetID { get; set; }

        public int LogNumber { get; set; }

        public int CorpCode { get; set; }

        public string FleetNumber { get; set; }

        public string UnitNumber { get; set; }

        public string VinNumber { get; set; }

        public string ContractType { get; set; }

        public string Make { get; set; }

        public string ModelCar { get; set; }

        public int ModelYear { get; set; }

        public decimal BookValue { get; set; }

        public decimal CapCost { get; set; }

        [Display(Name = "Inservice Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> Inservice_date { get; set; }
        
        [Display(Name = "Inservice Process")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> Inservice_process { get; set; }

        [Display(Name = "Original Inservice")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> Original_Inservice { get; set; }

        [Display(Name = "Original Process")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> Original_Process { get; set; }

        [Display(Name = "OffRoad")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> Offroad_date { get; set; }

        [Display(Name = "OffRoad Process")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> Offroad_process { get; set; }

        [Display(Name = "Sold")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> Sold_date { get; set; }

        [Display(Name = "Sold Process")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> Sold_process { get; set; }

        public string Cancel_Unit_ind { get; set; }

        public int Amort_term { get; set; }

        public int Leased_months_billed { get; set; }

        [Display(Name = "PSP")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> Psp_date { get; set; }

        [Display(Name = "PSP Process")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> Psp_process { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> End_date { get; set; }

        [Display(Name = "UnitAdd")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> UnitAdd_date { get; set; }

        public string ScontrNumber { get; set; }

        public decimal Amort { get; set; }

        public string LicenseNumber { get; set; }

        public string State { get; set; }  

        public decimal Roe { get; set; }

        public string DealerName { get; set; }

        [Display(Name = "Signed")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> SignedDate { get; set; }

        [Display(Name = "Delivery")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> Delivery_date { get; set; }

        public decimal Insurance { get; set; }

        public decimal Secdep { get; set; }

        public string DepartCode { get; set; }

        public decimal Residual_Amount { get; set; }

        public string Level { get; set; }

        public string LevelName { get; set; }

        public string TTL { get; set; }

        public string OutletCode { get; set; }

        public string OutletName { get; set; }

        //public FleetStatus FleetStatus { get; set; } Sirve para poner catalogos que no cambian a menudo

        //public string GetStringTypeInserviceDate  En caso de querer realizar validaciones o comparativas
        //{
        //    get { return Inservice_date != null ? Inservice_date.Value.ToShortDateString() : DateTime.MinValue.ToShortDateString(); }
        //}
    }
}