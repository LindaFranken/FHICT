using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumTry.Models;

namespace ForumTry.Context.Interfaces
{
    public interface IAccountContext
    {
        public void AddUser(string name, string password, string email);

        public void DeleteUser(int id);

        public bool Login(string name, string password);

        public List<Account> LoadUsers();
    }
}
