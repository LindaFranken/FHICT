using ForumTry.Context.Interfaces;
using ForumTry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumTry
{
    public class AccountRepository
    {
        private IAccountContext Ctx = null;

        public AccountRepository(IAccountContext ctx)
        {
            this.Ctx = ctx;
        }

        public void AddUser(string name, string password, string email)
        {
            Ctx.AddUser(name, password, email);
        }  
        
        public bool Login(string name, string password)
        {
            return Ctx.Login(name, password);
        }
    }
}
