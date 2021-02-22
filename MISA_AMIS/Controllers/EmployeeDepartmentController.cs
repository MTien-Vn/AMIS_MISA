using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.BL.Entity;
using Misa.BL.Interface.IService;
using Misa.BL.Interface.IService.IEmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA_AMIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDepartmentController : BaseEntityController<EmployeeDepartment>
    {
        IEmployeeDepartmentService employeeDepartmentService;
        public EmployeeDepartmentController(IEmployeeDepartmentService _employeeDepartmentService) : base(_employeeDepartmentService)
        {
            employeeDepartmentService = _employeeDepartmentService;
        }
    }
}
