using HRIS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using HRIS.Utility;

namespace HRIS.Controllers
{
    public class APIController : Controller
    {
        APIConnection api = new APIConnection();
        public APIResponse EmployeeCreateUpdate(EmployeeDTO dto)
        {
            dynamic data = new
            {
                EmployeeID = dto.EmployeeID,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                MobileNumber = dto.MobileNumber,
                Email = dto.Email,
            };

            return api.PostRequest("Employee/EmployeeCreateUpdate", data);
        }

    }
}