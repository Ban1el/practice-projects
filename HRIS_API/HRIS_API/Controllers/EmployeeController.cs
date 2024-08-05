using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRIS_API.Models.DTO;
using HRIS_API.Utilities;

namespace HRIS_API.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        public EmployeeUtils _empUtils = new EmployeeUtils();

        [HttpPost]
        [Route("EmployeeCreateUpdate")]
        public IHttpActionResult EmployeeCreateUpdate([FromBody] EmployeeDTO dto)
        {
            DataTable dt = _empUtils.EmployeeGetByID(dto.EmployeeID);

            if (dt.Rows.Count > 0) return BadRequest("Employee ID already exists!"); 

            int rows_affected = _empUtils.EmployeeCreateUpdate(dto);

            if (rows_affected > 0)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
    }
}