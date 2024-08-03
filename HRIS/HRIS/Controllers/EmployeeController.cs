using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRIS.Models.DTO;

namespace HRIS.Controllers
{
    public class EmployeeController : Controller
    {
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
            return Json("Success");
        }
    }
}