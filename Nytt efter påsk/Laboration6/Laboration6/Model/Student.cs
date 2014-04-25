using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Laboration6.Model
{
    public class Student
    {       
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Ett namn måste anges.")]
        [StringLength(40, ErrorMessage = "Namnet kan bestå av som mest 40 tecken.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "En adress måste anges.")]
        [StringLength(30, ErrorMessage = "Adressen kan bestå av som mest 30 tecken.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Ett postnummer måste anges.")]
        [StringLength(6, ErrorMessage = "Postnumret kan bestå av som mest 6 tecken.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "En ort måste anges.")]
        [StringLength(25, ErrorMessage = "Ort kan bestå av som mest 25 tecken.")]
        public string PostalAddress { get; set; }

        [Required(ErrorMessage = "Ett telefonnummer måste anges.")]
        [StringLength(20, ErrorMessage = "Telefonnumret kan bestå av som mest 20 tecken.")]
        public string Telephone { get; set; }

        public int CategoryID { get; set; }

    }
}