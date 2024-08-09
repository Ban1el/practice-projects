using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using HRIS_API.Models.DTO;
using HRIS_API.Utilities;
using Newtonsoft.Json;

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

        [HttpGet]
        [Route("EmployeeList")]
        public IHttpActionResult EmployeeGetList()
        {
            DataTable dt = _empUtils.EmployeeList();
            if (dt == null) return InternalServerError();


            List<EmployeeDTO> dto = new List<EmployeeDTO>();

            if(dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    EmployeeDTO empDTO = new EmployeeDTO();
                    empDTO.ID = Convert.ToInt32(row["ID"]);
                    empDTO.EmployeeID = row["EmployeeID"].ToString();
                    empDTO.FirstName = row["FirstName"].ToString();
                    empDTO.MiddleName = row["MiddleName"].ToString();
                    empDTO.LastName = row["LastName"].ToString();
                    empDTO.MobileNumber = row["MobileNumber"].ToString();
                    empDTO.Email = row["Email"].ToString();
                    empDTO.DateCreated = row["DateCreated"] != DBNull.Value ? Convert.ToDateTime(row["DateCreated"]) : (DateTime?)null;
                    empDTO.DateModified = row["DateModified"] != DBNull.Value ? Convert.ToDateTime(row["DateModified"]) : (DateTime?)null;
                    dto.Add(empDTO);
                }
            }

            APIResponseDTO response = new APIResponseDTO
            {
                statusCode = HttpStatusCode.OK,
                message = "Employee retrieved",
                data = JsonConvert.SerializeObject(new { data = dto }),
            };

            return Ok(response);
        }
    }
}