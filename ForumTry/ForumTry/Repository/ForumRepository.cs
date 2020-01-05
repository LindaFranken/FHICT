using ForumTry.Context.Interfaces;
using ForumTry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTry.Repository
{
    public class ForumRepository : IForumContext
    {
        private IForumContext Ctx;

        public ForumRepository(IForumContext ctx)
        {
            this.Ctx = ctx;
        }

        public bool Create(Forum forum)
        {
            return Ctx.Create(forum);
        }

        public void Update(Forum forum)
        {
            Ctx.Update(forum);
        }

        public bool Delete(int id)
        {
            return Ctx.Delete(id);
        }

        //public 

        public List<Forum> GetAll()
        {
            return Ctx.GetAll();
        }
    }
}
