using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace HRIS_API.Models
{
    public class DBInterface
    {
        //Execute Reader - Returns more than a single value.
        //Execute Non Query - To perform an insert, update or delete operation
        //Execute Scalar - Returns single(scalar) value. Queries that return the total number of rows in a table (Returns single value)

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

        public DataTable ExecuteReader(string storeProc, string cs, SqlCommand cmd)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    cmd.Connection = connection;
                    cmd.CommandText = storeProc;
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader != null)
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return dt;
        }

        public int ExecuteCUD(string storeProc, string cs, SqlCommand cmd)
        {
            int rows_affected = 0;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                cmd.Connection = connection;
                cmd.CommandText = storeProc;
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                rows_affected = cmd.ExecuteNonQuery(); 
            }

            return rows_affected;
        }
    }
}