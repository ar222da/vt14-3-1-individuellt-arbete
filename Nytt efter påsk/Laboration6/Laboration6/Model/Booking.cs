using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Laboration6.Model
{
    public class Booking
    {
        public int BookingID { get; set; }

        public int StudentID { get; set; }

        public string Name { get; set; }
        
        public int PieceOfFurnitureID { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Ett antal måste anges.")]
        public int Quantity { get; set; }
        
        public decimal Price { get; set; }
    }
}