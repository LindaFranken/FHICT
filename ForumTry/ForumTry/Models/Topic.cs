using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTry.Models
{
    public class Topic
    {
        public int ID { get; }

        public string Titel { get; set; }

        public string Inhoud { get; set; }

        public Topic(int id, string titel, string inhoud)
        {
            this.ID = id;
            this.Titel = titel;
            this.Inhoud = inhoud;
        }
    }
}
