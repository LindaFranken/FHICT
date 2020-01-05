using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ForumTry.Models
{
    public class TopicViewModel
    {
        public List<Topic> topicList = new List<Topic>();
        public int Id { get; set; }
        [Required(ErrorMessage = "Vul een titel in.")]
        [DataType(DataType.Text)]
        [Display(Name = "Titel")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Vul een inhoud in.")]
        [DataType(DataType.Text)]
        [Display(Name = "Inhoud")]
        public string Content { get; set; }

        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Vul een inhoud in.")]
        [Display(Name = "Hallo")]
        public string Reply { get; set; }

        public int ReplyID { get; set; }


        public List<Reply> replies = new List<Reply>();

        public int ForumID { get; set; }

        public string Username { get; set; }
    }
}
