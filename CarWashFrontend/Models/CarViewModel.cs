using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CarWashFrontend.Models
{
    public class CarViewModel
    {
        public int Id{ get; set; }

      

        [Required(ErrorMessage = "CarModel is required")]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "CarModelName")]
        public string CarModel { get; set; }
        
        
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status is required")]
        [StringLength(60)]

        public string Status { get; set; }
    }

}