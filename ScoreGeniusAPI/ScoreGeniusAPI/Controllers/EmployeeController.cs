using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ScoreGeniusAPI.Model;
using ScoreGeniusAPI.BusinessLogic;

namespace ScoreGeniusAPI.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<string>> test()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpPost("[action]")]
        public ActionResult Login([FromBody]UserLogin login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    ScoreGeniusAPI.BusinessLogic.BusinessLogic bl = new ScoreGeniusAPI.BusinessLogic.BusinessLogic();
                    if (login!=null && bl.ValidateUser(login))
                    {
                        return Ok(
                           "Success"
                           
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                return this.Ok(
                    "Falied"
                );
            }
            return Unauthorized();
        }

        [HttpPost("[action]")]
        public ActionResult SaveEmpDetails([FromBody]Employee Emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                ScoreGeniusAPI.BusinessLogic.BusinessLogic bl = new ScoreGeniusAPI.BusinessLogic.BusinessLogic();
                int result = bl.SaveEmplyee(Emp);
                return Ok(
                       result
                    );

            }

            //return Unauthorized();
        }


        [HttpPost("[action]")]
        public ActionResult RegistrationDetails([FromBody] userRegistration reg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                ScoreGeniusAPI.BusinessLogic.BusinessLogic bl = new ScoreGeniusAPI.BusinessLogic.BusinessLogic();
                int result = bl.userRegistration(reg);
                return Ok(
                       result
                    );

            }

            //return Unauthorized();
        }


        [HttpGet("[action]")]
        public ActionResult GetEmployeeDetails()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                ScoreGeniusAPI.BusinessLogic.BusinessLogic bl = new ScoreGeniusAPI.BusinessLogic.BusinessLogic();
                var result = bl.GetEmployee();
                return Ok(
                       result
                    );
            }
        }

        [HttpDelete("[action]")]
        public ActionResult DeleteEmployee(int empId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                ScoreGeniusAPI.BusinessLogic.BusinessLogic bl = new ScoreGeniusAPI.BusinessLogic.BusinessLogic();
                var result = bl.DeleteEmployee(empId);
                return Ok(
                       result
                    );
            }
        }

        

        [HttpGet("[action]")]
        public ActionResult GetEmployeeByID(int empId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                ScoreGeniusAPI.BusinessLogic.BusinessLogic bl = new ScoreGeniusAPI.BusinessLogic.BusinessLogic();
                var result = bl.GetEmployeeByID(empId);
                return Ok(
                       result
                    );
            }
        }



        [HttpPost("[action]")]
        public ActionResult EditEmployee([FromBody]Employee Emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                ScoreGeniusAPI.BusinessLogic.BusinessLogic bl = new ScoreGeniusAPI.BusinessLogic.BusinessLogic();
                var result = bl.EditEmployee(Emp);
                return Ok(
                       result
                    );
            }
        }
    }
}