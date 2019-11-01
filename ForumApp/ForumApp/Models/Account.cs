using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApp.Models
{
    public class Account
    {
        enum rol
        {
            gebruiker,
            moderator,
            admin
        };
        public int accountID { get; set; }

        [Required(ErrorMessage = "Vul een gebruikersnaam in.")]
        public string gebruikersnaam { get; set; }

        [Required(ErrorMessage = "Vul een wachtwoord in.")]
        [DataType(DataType.Password)]
        public string wachtwoord { get; set; }

        public string email { get; set; }

        private int currency;

        public Account(string naam, string ww)
        {
            this.gebruikersnaam = naam;
            this.wachtwoord = ww;
        }

        public Account(int id, string naam, string ww, string mail)
        {
            this.accountID = id;
            this.gebruikersnaam = naam;
            this.wachtwoord = ww;
            this.email = mail;
        }
    }
}
