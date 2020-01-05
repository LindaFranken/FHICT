using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ForumTry.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Vul een gebruikersnaam in.")]
        [DataType(DataType.Text)]
        [Display(Name = "Gebruikersnaam")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vul een wachtwoord in.")]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Het wachtwoord komt niet overeen.")]
        [DataType(DataType.Password)]
        [Display(Name = "Bevestig wachtwoord")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Vul een geldig emailadres in.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}
