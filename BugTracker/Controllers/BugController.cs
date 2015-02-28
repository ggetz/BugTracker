using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BugTracker.Controllers
{
    public class BugController : ApiController
    {
        // GET: api/Bug/5
        public BugModel Get(int id)
        {   
            using (var con = OpenConnection())
            {
                return Bug.GetBugByID(id, con);
            }
        }
       
        // POST: api/Bug
        public void Post(BugModel value)
        {
            if (String.IsNullOrEmpty(value.Name))
                return;
            Bug bug = new Bug();
            bug.Name = value.Name;
            bug.Description = value.Description;

            using (var con = OpenConnection())
            {
                bug.Save(con);
            }
        }

        // DELETE: api/Bug/5
        public void Delete(int id)
        {

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
