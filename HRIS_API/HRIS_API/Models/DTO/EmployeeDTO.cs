using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_API.Models.DTO
{
    public class EmployeeDTO
    {
        public int ID { get; set; }
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}