using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BugTracker
{
    public class Bug
    {
        public int BugID { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Bug()
        {
            //id is hash of the time submitted
            string time = System.DateTime.Now.ToString();
            BugID = time.GetHashCode();
        }

        public Bug(int id)
        {
            BugID = id;
        }

        public void Save(SqlConnection conn)
        {
            try
            {
                    string sqlInsertString = "INSERT INTO Bugs (BugID, Name, Description) VALUES (@bugID, @name, @description)";

                    var command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandText = sqlInsertString;

                    var idParam = new SqlParameter("@bugID", BugID);
                    var nameParam = new SqlParameter("@name", Name);
                    var descParam = new SqlParameter("@description", Description);

                    command.Parameters.AddRange(new SqlParameter[]{idParam, nameParam, descParam});
                    command.ExecuteNonQuery();
                    command.Connection.Close();
            }
            catch(Exception ex)
            {
                
            }
        }

        public static BugModel GetBugByID(int id, SqlConnection conn)
        {
            BugModel bug = new BugModel();
            

            try
            {
                string sqlQueryString = "SELECT * FROM Bugs";

                var command = new SqlCommand(sqlQueryString, conn);

                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var record = (IDataReader)reader;
                    if ((int)record[0] == id)
                    {
                        bug.BugID = (int)record[0];
                        bug.Name = (string)record[1];
                        bug.Description = (string)record[2];
                    }
                }

                command.Connection.Close();
            }
            catch (EvaluateException) { }

            return bug;
        }

        public static List<BugModel> GetBugList(SqlConnection conn)
        {
            List<BugModel> bugs = new List<BugModel>();

            try
            {
                string sqlQueryString = "SELECT * FROM Bugs";

                var command = new SqlCommand(sqlQueryString, conn);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var record = (IDataReader)reader;
                    BugModel bug = new BugModel();
                    bug.BugID = (int)record[0];
                    bug.Name = (string)record[1];
                    bug.Description = (string)record[2];
                    bugs.Add(bug);
                }

                command.Connection.Close();
            }
            catch (Exception ex)
            {

            }

            return bugs;
        }

        public static void DeleteBug(int id, SqlConnection conn)
        {

        }
    }
}