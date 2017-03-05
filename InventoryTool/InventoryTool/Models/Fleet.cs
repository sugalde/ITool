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

        [Display(Name = "Fleet Number")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 5)]
        public string FleetNumber { get; set; }

        [Display(Name = "Unit Number")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 7)]
        public string UnitNumber { get; set; }

        [Display(Name = "Vin Number")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 10)]
        public string VinNumber { get; set; }

        [Display(Name = "Contract Type")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(10, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string ContractType { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(10, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Make { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(20, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 5)]
        public string ModelCar { get; set; }

        public int ModelYear { get; set; }

        public decimal BookValue { get; set; }

        public decimal CapCost { get; set; }

        [Display(Name = "Inservice Date")]
        [DataType(DataType.Date)]
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

        public FleetCancelUnit FleetCancelUnit { get; set; }

        public int Amort_Term { get; set; }

        public int Leased_Months_Billed { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> End_date { get; set; }

        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(5, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string ScontrNumber { get; set; }

        public decimal Amort { get; set; }

        [Required(AllowEmptyStrings = true)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string  LicenseNumber { get; set; }

        public string State { get; set; }  

        public decimal Roe { get; set; }

        public string DealerName { get; set; }

        public decimal Insurance { get; set; }

        public decimal Secdep { get; set; }

        public string DepartmentCode { get; set; }

        public decimal Residual_Amount { get; set; }

        public string Level_1 { get; set; }

        public string Level_2 { get; set; }

        public string Level_3 { get; set; }

        public string Level_4 { get; set; }

        public string Level_5 { get; set; }

        public string Level_6 { get; set; }

        public string TTL { get; set; }

        public string OutletCode { get; set; }

        public string OutletName { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        //public string GetStringTypeInserviceDate  En caso de querer realizar validaciones o comparativas
        //{
        //    get { return Inservice_date != null ? Inservice_date.Value.ToShortDateString() : DateTime.MinValue.ToShortDateString(); }
        //}
    }
}