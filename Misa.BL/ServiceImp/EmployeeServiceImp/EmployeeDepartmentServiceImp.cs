using Misa.BL.Entity;
using Misa.BL.Interface.IRepository;
using Misa.BL.Interface.IRepository.IEmployeeRepository;
using Misa.BL.Interface.IService.IEmployeeService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.ServiceImp.EmployeeServiceImp
{
    public class EmployeeDepartmentServiceImp : BaseServiceImp<EmployeeDepartment>, IEmployeeDepartmentService
    {
        IEmployeeDepartmentRepository employeeDepartmentRepository;
        public EmployeeDepartmentServiceImp(IEmployeeDepartmentRepository _employeeDepartmentRepository) : base(_employeeDepartmentRepository)
        {
            employeeDepartmentRepository = _employeeDepartmentRepository;
        }
    }
}
