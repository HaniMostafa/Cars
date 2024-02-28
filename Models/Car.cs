using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
        public string Kilometer { get; set; }
        public string Trim { get; set; }
        public string FuelType { get; set; }
        public string Horsepower { get; set; }
        public string Color { get; set; }
        public string BodyType{ get; set; }
        public string ? ImgUrl{ get; set; }
        public int NumberOfDoors { get; set; }
        public int NumberCylinders{ get; set; }

        public int KindOfCarId { get; set; }

        [ForeignKey("KindOfCarId")]
        [ValidateNever]
        public KindOfCar KindOfCar { get; set; }

    }
}
