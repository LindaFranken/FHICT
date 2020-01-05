using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumTry.Context.Interfaces;
using ForumTry.Context;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using ForumTry.Models;


namespace ForumTry.Context.SQLContext
{
    public class ForumContext : DataConn, IForumContext
    {
        public bool Create(Forum forum)
        {
            OpenConn();

            string query = "insert into Forum (Titel, Omschrijving) output inserted.ForumID values (@title, @description)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@title", forum.Title);
            cmd.Parameters.AddWithValue("@description", forum.Description);

            forum.Id = (int)cmd.ExecuteScalar();
            if (forum.Id > -1)
            {
                conn.Close();
                return true;
            }

            conn.Close();

            return false;
        }

        public void Update(Forum forum)
        {
            OpenConn();

            string query = "update Forum set Titel = @title, Omschrijving = @description where ForumID = @ForumID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@title", forum.Title);
            cmd.Parameters.AddWithValue("@description", forum.Description);
            cmd.Parameters.AddWithValue("@ForumID", forum.Id);

            cmd.ExecuteNonQuery();
        }

        public bool Delete(int id)
        {
            try
            {
                OpenConn();

                string query = "delete from Forum where ForumID = @ForumID";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ForumID", id);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public List<Forum> GetAll()
        {
            List<Forum> forums = new List<Forum>();
            OpenConn();

            string query = "select * from Forum";
            SqlCommand cmd = new SqlCommand(query, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Forum forum = new Forum();
                    forum.Id = (int)reader["ForumID"];
                    forum.Title = (string)reader["Titel"];
                    forum.Description = (string)reader["Omschrijving"];
                    forums.Add(forum);
                }
            }
            conn.Close();
            return forums;
        }
    }
}
