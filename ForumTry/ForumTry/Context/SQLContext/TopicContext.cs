using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumTry.Context.Interfaces;
using ForumTry.Context;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using ForumTry.Models;

namespace ForumTry
{
    public class TopicContext : DataConn, ITopicContext
    {
        public bool Create(Topic topic)
        {
            OpenConn();

            //string query = "insert into Topic (ForumID, Titel, Inhoud, Datum, AccountID) output inserted.TopicID values (@forumID, @title, @content, GETDATE(), @accountID)";
            string query = "insert into Topic (ForumID, Titel, Inhoud, Datum, AccountID) output inserted.TopicID values(@forumID, @title, @content, GETDATE(), (Select AccountID From Account Where Gebruikersnaam = @username))";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@forumID", topic.ForumID);
            //cmd.Parameters.AddWithValue("@forumID", 1);
            cmd.Parameters.AddWithValue("@title", topic.Title);
            cmd.Parameters.AddWithValue("@content", topic.Content);
            cmd.Parameters.AddWithValue("@username", topic.Username);

            topic.Id = (int)cmd.ExecuteScalar();
            if (topic.Id > -1)
            {
                conn.Close();
                return true;
            }

            conn.Close();

            return false;
        }

        public void Delete(int id)
        {
            OpenConn();

            string query = "delete from Topic where TopicID = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public void Reply(string content, int id)
        {
            OpenConn();

            string query = "insert into Reactie (Inhoud, Datum, TopicID, AccountID) values (@content, GETDATE(), @topicID, @accountID)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@content", content);
            cmd.Parameters.AddWithValue("@topicID", id);
            cmd.Parameters.AddWithValue("@accountID", "1");
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public List<Reply> GetAllReplies(int id)
        {
            List<Reply> replies = new List<Reply>();
            OpenConn();

            //string query = "select Topic.Titel, Account.Gebruikersnaam from Topic inner join Account on Topic.AccountID = Account.AccountID";
            string query = "select * from Reactie where TopicID = @TopicID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TopicID", id);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Reply reply = new Reply();
                    reply.Id = (int)reader["ReactieID"];
                    reply.Content = (string)reader["Inhoud"];
                    reply.Created = (DateTime)reader["Datum"];
                    replies.Add(reply);
                }
            }
            conn.Close();
            return replies;
        }

        public List<Topic> GetAll(int id)
        {
            List<Topic> topics = new List<Topic>();
            OpenConn();

            //string query = "select Topic.Titel, Account.Gebruikersnaam from Topic inner join Account on Topic.AccountID = Account.AccountID";
            string query = "select * from Topic where ForumID = @ForumID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ForumID", id);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Topic topic = new Topic();
                    topic.Id = (int)reader["TopicID"];
                    topic.Title = (string)reader["Titel"];
                    topic.Created = (DateTime)reader["Datum"];
                    topics.Add(topic);
                }
            }
            conn.Close();
            return topics;
        }

        public Topic GetByID(int id)
        {
            OpenConn();
            string query = "select * from Topic where TopicID = @TopicID";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@TopicID", id);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                try
                {
                    Topic t = new Topic(id);
                    while (reader.Read())
                    {
                        t.Title = reader["Titel"].ToString();
                        t.Content = reader["Inhoud"].ToString();
                        t.Created = (DateTime)reader["Datum"];
                    }

                    CloseConn();
                    return t;
                }
                catch
                {

                    CloseConn();
                    return new Topic(-1);
                }
            }
        }
    }
}
