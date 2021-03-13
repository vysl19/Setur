using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using Npgsql;

namespace Setur.Migration
{
    class Program
    {
        static void Main(string[] args)
        {    
            var connectionString= ConfigurationManager.ConnectionStrings["PostgreConnection"].ConnectionString;
            string path = Path.Combine(Environment.CurrentDirectory.Replace("\\bin\\Debug\\netcoreapp3.1",""), @"sql.txt");            
            var sql= File.ReadAllText(path);
            if (!string.IsNullOrEmpty(sql))
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
            
        }
    }
}
