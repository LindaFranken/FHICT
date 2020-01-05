using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ForumTry.Context.Interfaces;
using ForumTry.Context;
using Microsoft.Data.SqlClient;
using ForumTry.Models;

namespace ForumTry
{
    public class AccountContext : DataConn, IAccountContext
    {

        public void AddUser(string name, string password, string email)
        {
            OpenConn();

            string query = "insert into Account (Gebruikersnaam, Wachtwoord, Email, Rol) values (@username, @password, @email, @rol)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", name);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@rol", "Gebruiker");
            cmd.ExecuteScalar();

            conn.Close();
        }

        public void DeleteUser(int id)
        {
            OpenConn();

            string query = "delete from Account where AccountID = @ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);
        }

        public bool Login(string name, string password)
        {

            if (name == "" || password == "")
            {
                return false;
            }
            else
            {
                string query = "SELECT * FROM Account WHERE Gebruikersnaam = @username AND Wachtwoord = @password";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@username", name);
                cmd.Parameters.AddWithValue("@password", password);

                OpenConn();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        conn.Close();
                        return true;
                    }
                    else
                    {
                        conn.Close();
                        return false;
                    }
                }
            }
        }

        public List<Account> LoadUsers()
        {
            List<Account> accounts = new List<Account>();
            OpenConn();

            //string query = "select Topic.Titel, Account.Gebruikersnaam from Topic inner join Account on Topic.AccountID = Account.AccountID";
            string query = "select * from Account";
            SqlCommand cmd = new SqlCommand(query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Account account = new Account();
                    account.Username = (string)reader["Gebruikersnaam"];
                    accounts.Add(account);
                }
            }
            conn.Close();
            return accounts;
        }
    }
}
