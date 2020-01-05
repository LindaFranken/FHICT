using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTry.Models
{
    public class Topic
    {
        public int Id { get; set; }

        public string Onderwerp { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; }

        public string Reply { get; set; }

        public int ForumID { get; set; }

        public List<Reply> replies = new List<Reply>();

        //Acountnaam hierin zetten
        public string Username { get; set; }

        public Topic()
        {

        }

        public Topic(int id)
        {

        }
    }
}
