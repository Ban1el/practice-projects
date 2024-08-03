using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

namespace HRIS_API.Models
{
    public class DBInterface
    {
        //Notes
        //Execute Reader - Returns more than a single value.
        //Execute Non Query - To perform an insert, update or delete operation
        //Execute Scalar - Returns single(scalar) value. Queries that return the total number of rows in a table

        public string GetConnectionString(int conn = 0)
        {
            string cs = "";

            switch (conn)
            {
                case 0:
                    cs = ConfigurationManager.ConnectionStrings["DBConnHRIS"].ConnectionString;
                    break;
                default:
                    cs = "";
                    break;
            }

            return cs;
        }

        //public DataTable ExecuteReader()
        //{

        //}
    }
}