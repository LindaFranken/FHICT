using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumTry.Context.Interfaces;
using ForumTry.Models;

namespace ForumTry
{
    public class TopicRepository : ITopicContext
    {
        private ITopicContext Ctx;

        public TopicRepository(ITopicContext ctx)
        {
            this.Ctx = ctx;
        }

        public void Delete(int id)
        {
            Ctx.Delete(id);
        }

        public bool Create(Topic topic)
        {
            return Ctx.Create(topic);
        }

        public void Reply(string content, int id)
        {
            Ctx.Reply(content, id);
        }

        public List<Topic> GetAll(int id)
        {
            return Ctx.GetAll(id);
        }

        public Topic GetByID(int id)
        {
            return Ctx.GetByID(id);
        }

        public List<Reply> GetAllReplies(int id)
        {
            return Ctx.GetAllReplies(id);
        }
    }
}
