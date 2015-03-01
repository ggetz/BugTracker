using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BugTracker
{
    public class DatabaseConnection
    {
        private string projectsConnection = "ProjectsConnection";

        private static SqlConnection OpenConnection(string databaseConnection)
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings[databaseConnection].ToString();
                return new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void CreateProjectsTable()
        {
            using (var conn = OpenConnection(projectsConnection))
            {

            }
        }

        public void AddProject(Project project)
        {
            using (var conn = OpenConnection(projectsConnection))
            {

            }
        }

        public List<Project> GetProjectList()
        {
            var projects = new List<Project>();

            using (var conn = OpenConnection(projectsConnection))
            {

            }

            return projects;
        }
    }
}