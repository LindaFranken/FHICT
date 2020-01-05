using ForumTry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTry.Context.Interfaces
{
    public interface ITopicContext
    {
        public bool Create(Topic topic);

        public void Delete(int id);

        //public Topic Show(int id);

        public void Reply(string content, int id);

        public List<Topic> GetAll(int id);

        public List<Reply> GetAllReplies(int id);

        Topic GetByID(int id);
    }
}
