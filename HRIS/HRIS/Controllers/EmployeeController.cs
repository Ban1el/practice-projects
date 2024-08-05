using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using HRIS.Models.DTO;
using Newtonsoft.Json.Linq;

namespace HRIS.Controllers
{
    public class EmployeeController : Controller
    {
        APIController service = new APIController();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();

            return View(employeeDTO);
        }

        [HttpPost]
        public ActionResult Add(EmployeeDTO dto)
        {
            APIResponse result = service.EmployeeCreateUpdate(dto);

            var jsonResponse = new
            {
                StatusCode = result.statusCode,
                Message = result.message,
            };

            return Json(jsonResponse);
        }
    }
}