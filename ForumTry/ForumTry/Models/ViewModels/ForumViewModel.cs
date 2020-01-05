using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTry.Models
{
    public class ForumViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vul een titel in.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Vul een omschrijving in.")]
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public List<Topic> topics = new List<Topic>();

        public List<Forum> forumList = new List<Forum>();
    }
}

