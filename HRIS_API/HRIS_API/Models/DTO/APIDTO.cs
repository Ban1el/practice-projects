using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace HRIS_API.Models.DTO
{
    public class APIResponseDTO
    {
        public HttpStatusCode statusCode { get; set; }
        public string message { get; set; }
        public dynamic data { get; set; }
    }
}