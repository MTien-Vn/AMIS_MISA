using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.BL.Entity;
using Misa.BL.Interface.IService;
using Misa.BL.Interface.IService.IEmployeeService;
using Misa.BL.Model;
using Misa.BL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA_AMIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseEntityController<Employee>
    {
        IEmployeeService employeeService;
        public EmployeeController(IEmployeeService _employeeService) : base(_employeeService)
        {
            this.employeeService = _employeeService;
        }

        [HttpGet("filter/{key}/{page}/{limmit}")]
        public IEnumerable<Employee> FilterEmployee(string key, long page, long limmit)
        {
            return employeeService.SearchEmployeeByKey(key, page, limmit);
        }

        [HttpGet("getEmployeeByEmployeeCode/{employeeCode}")]
        public IEnumerable<Employee> GetEmployeeByCode(string employeeCode)
        {
            return employeeService.GetEmployeeByEmployeeCode(employeeCode);
        }

        [HttpGet("numberEmployee/{key}")]
        public long NumberEmployee(string key)
        {
            return employeeService.CountEmployeeByKey(key);
        }

        [HttpGet("employeeCodeMax")]
        public string GetEmployeeCodeMax()
        {
            return employeeService.GetEmployeeCodeMax();
        }

        [HttpPost("saveEmployee")]
        public ServiceResult SaveEmpoyee([FromBody] EmployeeModel employeeModel)
        {
            return employeeService.SaveEmployee(employeeModel);
        }

        [HttpPut("updateEmployee")]
        public ServiceResult UpdateEmployee([FromBody] EmployeeModel employeeModel)
        {
            return employeeService.SaveEmployee(employeeModel);
        }

        [HttpDelete("{code}")]
        public ServiceResult DeleteEmployee(string code)
        {
            return employeeService.DeleteEmployeeByEmployeeCode(code);
        }
    }
}
