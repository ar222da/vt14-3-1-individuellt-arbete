using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Laboration6.Model
{
    public class PieceOfFurniture
    {
        public int PieceOfFurnitureID { get; set; }

        [Required(ErrorMessage = "En beskrivning måste anges.")]
        [StringLength(50, ErrorMessage = "Beskrivning kan bestå av som mest 50 tecken.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Ett pris måste anges.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Ett inköpspris måste anges.")]
        public decimal BuyingPrice { get; set; }

        [Required(ErrorMessage = "Ett antal måste anges.")]
        public int Quantity { get; set; }
        
    }
}