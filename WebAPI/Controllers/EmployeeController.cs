using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        public static List<Employee> employees = new List<Employee>() {
                   new Employee(){Id=1,Name="Mostafa",Age=17,Salary=5000},
                   new Employee(){Id=2,Name="Alaa",Age=27,Salary=4000},
                   new Employee(){Id=3,Name="Ahmed",Age=37,Salary=1234},
                   new Employee(){Id=4,Name="Mohamed",Age=29,Salary=3455},
                   new Employee(){Id=5,Name="Ali",Age=26,Salary=3536},
                   new Employee(){Id=6,Name="Osama",Age=40,Salary=7700},
                   new Employee(){Id=7,Name="Mahmoud",Age=15,Salary=8000}
         };

       public List<Employee> GetAll()
        {
            return employees;
        }

        ///Web API V01
        //public HttpResponseMessage GetById(int id)
        //{
        //    Employee e = employees.Find(n => n.Id == id);
        //    if (e==null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, e);
        //}

        ///Web API V02

        public IHttpActionResult GetById(int id)
        {
            Employee e = employees.Find(n => n.Id == id);
            if (e == null)
            {
                return NotFound();
            }
            return Ok(e);
        }

        [Route("Api/Emp/{Name}")]
        public IHttpActionResult GetByName(string name)
        {
            Employee e= employees.Find(n => n.Name.ToLower() == name.ToLower());
            if (e is null)
            {
                return NotFound();

            }
            return Ok(e);
        }

        public IHttpActionResult PostEmployee(Employee e)
        {
            if (e is null)
            {
                return BadRequest();
            }
            employees.Add(e);
            return Created("Created",employees);
        }

        public IHttpActionResult put([FromUri] int a,[FromBody]Employee e)
        {
            Employee em = employees.Find(se => se.Id == a);
            if (em is null)
            {
                return NotFound();
            }
            else if (e is null)
            {
                return BadRequest();

            }
            else
            em.Id = e.Id;
            em.Name = e.Name;
            em.Age = e.Age;
            em.Salary = e.Salary;
            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Delete(int id)
        {
            Employee e= employees.Find(u => u.Id == id);
            if (e is null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            employees.Remove(e);
            return Ok(employees);
        }


    }


}
