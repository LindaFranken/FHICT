using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ForumTry.Context
{
    public class DataConn
    {
        const string connectionString = "Server=mssql.fhict.local;Database=dbi410831;User Id=dbi410831;Password=PeaceOut112;";
        SqlConnection conn = new SqlConnection(connectionString);

        public SqlConnection OpenConn()
        {
            try
            {
                conn.Open();
            }
            catch
            {
                throw;   
            }
            return conn;
        }

        public void CloseConn()
        {
            try
            {
                conn.Close();
            }
            catch
            {

            }
        }
    }
}
