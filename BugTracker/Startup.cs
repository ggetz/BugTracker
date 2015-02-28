using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BugTracker.Startup))]

namespace BugTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //CreateTables();
        }

        private void CreateTables()
        {
            using (var conn = OpenConnection())
            {
                string sqlInsertString = "IF object_id('Bugs') is not null BEGIN CREATE TABLE Bugs (BugID int NOT NULL, Name varchar(255), Description varchar(511)) END;";

                var command = new SqlCommand();
                command.Connection = conn;
                command.Connection.Open();
                command.CommandText = sqlInsertString;

                command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }

        private SqlConnection OpenConnection()
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
                return new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
