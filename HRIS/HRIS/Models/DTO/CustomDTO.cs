using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HRIS.Models.DTO
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

    public class APIResponseDTO
    {
        public HttpStatusCode statusCode { get; set; }
        public string message { get; set; }
        public dynamic data { get; set; }
    }
}