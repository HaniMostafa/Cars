using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Owner
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Phone { get; set; }
        [ValidateNever]
        public string Image { get; set; }
        [Required]

        public string ?FaceBookUrl { get; set; }
        [Required]

        public string?Twitter { get; set; }
        [Required]

        public string?Instigram { get; set; }
        [Required]

        public string?Olx { get; set; }
        [Required]

        public string?Gps { get; set; }





    }
}
