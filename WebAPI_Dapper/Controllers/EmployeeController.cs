using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace WebAPI_Dapper.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        IRepository<Employee> _employeeRepository;
        public EmployeeController(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _employeeRepository.Get(id);
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody]Employee value)
        {
            return _employeeRepository.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            _employeeRepository.Update(employee);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _employeeRepository.Delete(id);
        }
    }
}
