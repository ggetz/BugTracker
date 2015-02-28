using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BugTracker.Controllers
{
    public class BugListController : ApiController
    {
        // GET: api/BugList
        public IEnumerable<BugModel> Get()
        {
            List<BugModel> bugs;
            using (var con = OpenConnection())
            {
               bugs = Bug.GetBugList(con);
            }

            return bugs;
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
