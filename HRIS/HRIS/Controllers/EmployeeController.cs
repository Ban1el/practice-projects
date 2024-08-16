using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using HRIS.Models.DTO;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
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

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(EmployeeDTO dto)
        {
            APIResponseDTO result = service.EmployeeCreateUpdate(dto);

            var jsonResponse = new
            {
                StatusCode = result.statusCode,
                Message = result.message,
            };

            return Json(jsonResponse);
        }

        [HttpPost]
        public ActionResult EmployeeList()
        {
            APIResponseDTO result = service.EmployeeGetList();
           
            return Json(new { StatusCode = result.statusCode, Message = result.message, Employees = result.data }, JsonRequestBehavior.AllowGet);
        }
    }
}