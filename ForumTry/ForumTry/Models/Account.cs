using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ForumTry.Models
{
    public class Account
    {
        enum rol
        {
            gebruiker,
            moderator,
            admin
        };
        public int AccountId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        //private int Currency;

        public List<Topic> topics = new List<Topic>();

        public List<Reply> replies = new List<Reply>();

        public Account()
        {

        }

        public Account(string name, string pw)
        {
            this.Username = name;
            this.Password = pw;
        }

        public Account(int id, string name, string pw, string mail)
        {
            this.AccountId = id;
            this.Username = name;
            this.Password = pw;
            this.Email = mail;
        }
    }
}
