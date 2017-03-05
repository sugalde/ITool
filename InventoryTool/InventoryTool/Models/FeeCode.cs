using System.ComponentModel.DataAnnotations;

namespace InventoryTool.Models
{
    public class FeeCode
    {
        [Key]
        public int FeeCode_Id { get; set; }

        [Display(Name = "FLEET")]
        [Required(ErrorMessage = "You must enter {0}")]
        public int Fleet { get; set; }

        [Display(Name = "UNIT")]
        [Required(ErrorMessage = "You must enter {0}")]
        public int Unit { get; set; }

        [Display(Name = "LOG NUMBER")]
        [Required(ErrorMessage = "You must enter {0}")]
        public int LogNo { get; set; }

        [Display(Name = "CAP COST")]
        [Required(ErrorMessage = "You must enter {0}")]
        public decimal CapCost { get; set; }

        [Display(Name = "BOOK VALUE")]
        [Required(ErrorMessage = "You must enter {0}")]
        public decimal BookValue{ get; set; }

        [Display(Name = "TERM")]
        [Required(ErrorMessage = "You must enter {0}")]
        public int Term { get; set; }

        [Display(Name = "LPIS")]
        [Required(ErrorMessage = "You must enter {0}")]
        public int Lpis { get; set; }

        [Display(Name = "ONRD DAT")]
        [Required(ErrorMessage = "You must enter {0}")]
        public int OnRdDat { get; set; }

        [Display(Name = "OFRD DAT")]
        [Required(ErrorMessage = "You must enter {0}")]
        public int OfRdDat { get; set; }

        [Display(Name = "SCONTR")]
        [Required(ErrorMessage = "You must enter {0}")]
        public string Scontr { get; set; }

        [Display(Name = "INS PREMIUM")]
        [Required(ErrorMessage = "You must enter {0}")]
        public decimal InsPremium { get; set; }

        [Display(Name = "RESIDUAL AMT")]
        [Required(ErrorMessage = "You must enter {0}")]
        public decimal ResidualAmt { get; set; }

        [Display(Name = "FEE")]
        [Required(ErrorMessage = "You must enter {0}")]
        public int Fee { get; set; }

        [Display(Name = "DESC")]
        [Required(ErrorMessage = "You must enter {0}")]
        public string Desc { get; set; }

        [Display(Name = "MM/YY")]
        [Required(ErrorMessage = "You must enter {0}")]
        public int MMYY { get; set; }

        [Display(Name = "START")]
        [Required(ErrorMessage = "You must enter {0}")]
        public int Start { get; set; }

        [Display(Name = "STOP")]
        [Required(ErrorMessage = "You must enter {0}")]
        public int Stop { get; set; }

        [Display(Name = "AMT")]
        [Required(ErrorMessage = "You must enter {0}")]
        public decimal Amt { get; set; }

        [Display(Name = "METHOD")]
        public string Method { get; set; }

        [Display(Name = "RATE")]
        [Required(ErrorMessage = "You must enter {0}")]
        public string Rate { get; set; }

        [Display(Name = "BL")]
        [Required(ErrorMessage = "You must enter {0}")]
        public string BL { get; set; }

        [Display(Name = "AC")]
        //[Required(ErrorMessage = "You must enter {0}")]
        public string AC { get; set; }

        [Display(Name = "CREATED BY")]
        //[Required(ErrorMessage = "You must enter {0}")]
        public string Createdby { get; set; }

        [Display(Name = "CREATED")]
        //[Required(ErrorMessage = "You must enter {0}")]
        public string Created { get; set; }
    }
}
//FLEET	UNIT	LOG-NO	CAPCOST	BOOK VALUE	TERM	LPIS	ONRD DAT	OFRD DAT	SCONTR	INS PREMIUM	RESIDUAL AMT	FEE	DESC	MM/YY	START	STOP	AMT	METHOD	RATE	BL	AC                                 
