using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tugasAlMiraj.Models.masterModel
{
    public class areaModel
    {
        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name Required")]
        public string name { get; set; }

        public string description { get; set; }
    }
}