using Misa.BL.Entity;
using Misa.BL.Interface.IDBConnector;
using Misa.BL.Interface.IRepository.IEmployeeRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.DL.RepositoryImp.EmployeeRepositoryImp
{
    public class EmployeeDepartmentRepositoryImp : BaseRepositoryImp<EmployeeDepartment>, IEmployeeDepartmentRepository
    {
        public EmployeeDepartmentRepositoryImp(IDBConnector iDBConnector) : base(iDBConnector)
        {
        }
    }
}
