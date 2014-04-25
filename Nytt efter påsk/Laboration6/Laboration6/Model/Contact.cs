using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Laboration6.Model
{
    public class Contact
    {
        public int ContactID { get; set; }

        [Required(ErrorMessage = "En emailadress måste anges.")]
        [EmailAddress(ErrorMessage = "Emailadressen verkar inte vara korrekt.")]
        [StringLength(50, ErrorMessage = "Emailadressen kan bestå av som mest 50 tecken.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Ett förnamn måste anges.")]
        [StringLength(50, ErrorMessage = "Förnamnet kan bestå av som mest 50 tecken.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ett efternamn måste anges.")]
        [StringLength(50, ErrorMessage = "Förnamnet kan bestå av som mest 50 tecken.")]
        public string LastName { get; set; }
    
    }
}