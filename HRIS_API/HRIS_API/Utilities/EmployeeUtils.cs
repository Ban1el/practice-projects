using HRIS_API.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using HRIS_API.Models.DTO;

namespace HRIS_API.Utilities
{
    public class EmployeeUtils : DBInterface
    {
        public static DBInterface _dbi = new DBInterface();
        public static string conn = _dbi.GetConnectionString();
        public int EmployeeCreateUpdate(EmployeeDTO dto)
        {
            int rows_affected = 0;
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Parameters.AddWithValue("@EmployeeID", dto.EmployeeID);
                cmd.Parameters.AddWithValue("@FirstName", dto.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", dto.MiddleName);
                cmd.Parameters.AddWithValue("@LastName", dto.LastName);
                cmd.Parameters.AddWithValue("@MobileNumber", dto.MobileNumber);
                cmd.Parameters.AddWithValue("@Email", dto.Email);
                cmd.Parameters.AddWithValue("@CurrentDate", DateTime.Now);

                rows_affected = ExecuteCUD("usp_Employee_CreateUpdate", conn, cmd);

            }
            catch (Exception ex)
            {

            }

            return rows_affected;
        }

        public DataTable EmployeeGetByID(string empID)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dt = null;
            try
            {
                cmd.Parameters.AddWithValue("@Identifier", "GetEmpByID");
                cmd.Parameters.AddWithValue("@EmpID", empID);

                dt = ExecuteReader("usp_Employee_get", conn, cmd);
            }
            catch (Exception ex)
            {

            }

            return dt;
        }
    }
}