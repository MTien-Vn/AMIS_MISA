using Misa.BL.Entity;
using Misa.BL.Interface.IDBConnector;
using Misa.BL.Interface.IRepository.IEmployeeRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.DL.RepositoryImp.EmployeeRepositoryImp
{
    public class EmployeeAccountBankRepositoryImp : BaseRepositoryImp<EmployeeAccountBank>, IEmployeeAccountBankRepository
    {
        public EmployeeAccountBankRepositoryImp(IDBConnector iDBConnector) : base(iDBConnector)
        {
        }
    }
}
