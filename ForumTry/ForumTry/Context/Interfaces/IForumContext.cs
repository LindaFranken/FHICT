using ForumTry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTry.Context.Interfaces
{
    public interface IForumContext
    {
        public bool Create(Forum forum);

        public void Update(Forum forum);

        public bool Delete(int id);

        public List<Forum> GetAll();
    }
}
