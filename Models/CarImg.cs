using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CarImg
    {
        public int Id { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        public int CarId { get; set; }
        [ForeignKey("CarId")]
        public Car Car { get; set; }
    }
}
