using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApp.Models
{
    public class Topic
    {
        enum onderwerp
        {
            Algemeen,
            Help
        };
        private string titel;
        private string inhoud;
        private DateTime datum;
    }
}
