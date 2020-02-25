using ASP_202002_CarCrud.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_202002_CarCrud.Models
{
    public class Car
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Kötező megadni!")]
        [StringLength(15, ErrorMessage = "Maximum 15 karakter lehet!")]
        [Display(Name = "Márka és típus")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Kötező megadni!")]
        [Range(100,9999, ErrorMessage = "Az ár 100e-9999e között legyen!")]
        [Display(Name = "Autó ára")]
        [PriceValidation(ErrorMessage = "Százzal legyen osztható", Divider = 100)]
        public int Price { get; set; }

        //képkezelés -->db

        [NotMapped]
        [Display(Name = "Autó fényképe")]
        public IFormFile PhotoForm { get; set; }

        public string ContentType { get; set; }

        public byte[] PhotoData { get; set; }
    }
}
