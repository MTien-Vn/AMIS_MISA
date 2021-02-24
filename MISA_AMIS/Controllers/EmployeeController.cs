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

        /// <summary>
        /// api lọc nhân viên theo từ khóa
        /// </summary>
        /// <param name="key"></param>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <returns></returns>
        /// created: Manh Tien(22/2/2021)
        [HttpGet("filter/{key}/{page}/{limmit}")]
        public IEnumerable<Employee> FilterEmployee(string key, long page, long limmit)
        {
            return employeeService.SearchEmployeeByKey(key, page, limmit);
        }

        /// <summary>
        /// lấy nhân viên theo mã nhân viên
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        /// created: Manh Tien(22/2/2021)
        [HttpGet("getEmployeeByEmployeeCode/{employeeCode}")]
        public IEnumerable<Employee> GetEmployeeByCode(string employeeCode)
        {
            return employeeService.GetEmployeeByEmployeeCode(employeeCode);
        }

        /// <summary>
        /// lấy số lượng nhân viên theo tù khóa
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// created: Manh Tien(22/2/2021)
        [HttpGet("numberEmployee/{key}")]
        public long NumberEmployee(string key)
        {
            return employeeService.CountEmployeeByKey(key);
        }

        /// <summary>
        /// api lấy mã nhân viên lớn nhất trong db
        /// </summary>
        /// <returns></returns>
        /// created: Manh Tien(22/2/2021)
        [HttpGet("employeeCodeMax")]
        public string GetEmployeeCodeMax()
        {
            return employeeService.GetEmployeeCodeMax();
        }

        /// <summary>
        /// api lưu nhân viên
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        [HttpPost("saveEmployee")]
        public ServiceResult SaveEmpoyee([FromBody] EmployeeModel employeeModel)
        {
            return employeeService.SaveEmployee(employeeModel);
        }

        /// <summary>
        /// api cập nhật nhân viên
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        /// created: Manh Tien(22/2/2021)
        [HttpPut("updateEmployee")]
        public ServiceResult UpdateEmployee([FromBody] EmployeeModel employeeModel)
        {
            return employeeService.SaveEmployee(employeeModel);
        }

        /// <summary>
        /// xóa nhân viên theo mã nhân viên
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// created: Manh Tien(22/2/2021)
        [HttpDelete("{code}")]
        public ServiceResult DeleteEmployee(string code)
        {
            return employeeService.DeleteEmployeeByEmployeeCode(code);
        }
    }
}
