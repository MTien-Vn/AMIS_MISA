using Dapper;
using Misa.BL.Entity;
using Misa.BL.Interface.IDBConnector;
using Misa.BL.Interface.IRepository.IEmployeeRepository;
using System.Data;

namespace Misa.DL.RepositoryImp.EmployeeRepositoryImp
{
    public class EmployeeRepositoryImp : BaseRepositoryImp<Employee>, IEmployeeRepository
    {
        public EmployeeRepositoryImp(IDBConnector iDBConnector) : base(iDBConnector)
        {
        }

        public string GetEmployeeCodeMax()
        {
            var storeName = $"Proc_GetEmployeeCodeMax";
            string employeeCodeMax = (string)GetDBConnection().ExecuteScalar(storeName, commandType: CommandType.StoredProcedure);
            return employeeCodeMax;
        }
    }
}
