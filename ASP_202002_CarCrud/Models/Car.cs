using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_202002_CarCrud.Models
{
    public class Car
    {
        [Key]
        public string Id { get; set; }

        [Display(Name = "Márka és típus")]
        public string Model { get; set; }

        [Display(Name = "Autó ára")]
        public int Price { get; set; }
    }
}
