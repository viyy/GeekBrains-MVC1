using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainModels.Models;
using WebStore.Interfaces.Services;

namespace WebStore.ServicesHosting.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeApiController : Controller
    {
        private readonly IEmployeesData _employeesData;
        public EmployeeApiController(IEmployeesData employeesData)
        {
            _employeesData = employeesData ?? throw new ArgumentNullException(nameof(employeesData));
        }
        [HttpGet, ActionName("Get")]
        public IEnumerable<Employee> GetAll()
        {
            return _employeesData.GetAll();
        }
        [HttpGet("{id}"), ActionName("Get")]
        public Employee GetById(int id)
        {
            return _employeesData.GetById(id);
        }
        [HttpPost, ActionName("Post")]
        public void AddNew([FromBody]Employee model)
        {
            _employeesData.AddNew(model);
        }
        [HttpPut("{id}"), ActionName("Put")]
        public Employee UpdateEmployee(int id, [FromBody]Employee entity)
        {
            return _employeesData.UpdateEmployee(id, entity);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeesData.Delete(id);
        }
        [NonAction]
        public void Commit()
        {
        }
    }
}