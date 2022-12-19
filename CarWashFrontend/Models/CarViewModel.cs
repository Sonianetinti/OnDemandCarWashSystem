using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarWashFrontend.Models
{
    public class CarViewModel
    {
        public int Id{ get; set; }
        public string CarModel { get; set; }    
        public string Status { get; set; }  
    }
}