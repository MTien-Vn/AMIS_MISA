using Misa.BL.Entity;
using Misa.BL.Enum;
using Misa.BL.Interface.IRepository;
using Misa.BL.Interface.IRepository.IEmployeeRepository;
using Misa.BL.Interface.IService.IEmployeeService;
using Misa.BL.IService.IEmployeeService;
using Misa.BL.Model;
using Misa.BL.Properties;
using Misa.BL.Service;
using Misa.BL.ValidateData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Misa.BL.ServiceImp.EmployeeServiceImp
{
    public class EmployeeServiceImp : BaseServiceImp<Employee>, IEmployeeService
    {
        IEmployeeRepository employeeRepository;
        IEmployeeAccountBankService employBankService;
        public EmployeeServiceImp(IEmployeeRepository _employeeRepository, IEmployeeAccountBankService _empAccBankService) : base(_employeeRepository)
        {
            employeeRepository = _employeeRepository;
            employBankService = _empAccBankService;
        }

        #region count employee
        public long CountEmployeeByKey(string key)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeeCode");
            values.Add(key);
            var numberEntity = employeeRepository.CountEntity(fieldNames, values);
            if(numberEntity == 0)
            {
                fieldNames.Remove("EmployeeCode");
                fieldNames.Add("EmployeeName");
                numberEntity = employeeRepository.CountEntity(fieldNames, values);
            }
            return numberEntity;
        }
        #endregion

        #region get employee
        public IEnumerable<Employee> GetEmployeeByEmail(string email)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("Email");
            values.Add(email);
            return employeeRepository.GetData(0, 1, fieldNames, values);
        }

        public IEnumerable<Employee> GetEmployeeByEmployeeCode(string code)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeeCode");
            values.Add(code);
            return employeeRepository.GetData(0, 1, fieldNames, values);
        }

        public IEnumerable<Employee> GetEmployeeByPhoneNumber(string phoneNumber)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("PhoneNumber");
            values.Add(phoneNumber);
            return employeeRepository.GetData(0, 1, fieldNames, values);
        }

        public string GetEmployeeCodeMax()
        {
            return employeeRepository.GetEmployeeCodeMax();
        }

        public IEnumerable<Employee> GetEmployeesByEmployeeDepartment(string employeeDepartmentId, long page, long limmit)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeeDepartmentId");
            values.Add(employeeDepartmentId);
            return employeeRepository.GetData(page, limmit, fieldNames, values);
        }

        public IEnumerable<Employee> GetEmployeesByName(string name, long page, long limmit)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeeName");
            values.Add(name);
            return employeeRepository.GetData(page, limmit, fieldNames, values);
        }
        #endregion

        #region save employee

        public ServiceResult SaveEmployee(EmployeeModel employeeModel)
        {
            var employee = employeeModel.Employee;
            var employeeAccountBank = employeeModel.EmployeeAccountBanks;

            if (employee.EmployeeId.Equals(Guid.Empty))
            {
                
                employee.EmployeeId = new Guid();
                var serResultEmployee = this.InsertT(employee);
                if(serResultEmployee.MisaCode == MisaEmun.Scuccess)
                {
                    foreach (var accountBank in employeeAccountBank)
                    {
                        var serResultBank = employBankService.InsertT(accountBank);
                        if(serResultBank.MisaCode != MisaEmun.Scuccess)
                        {
                            return serResultBank;
                        }
                    }
                }
                return serResultEmployee;
            }
            else
            {
                var serResultEmployee = this.UpdateT(employee, employee.EmployeeId.ToString());
                if (serResultEmployee.MisaCode == MisaEmun.Scuccess)
                {
                    foreach (var accountBank in employeeAccountBank)
                    {
                        var serResultBank = employBankService.UpdateT(accountBank, accountBank.EmployeeAccountId.ToString());
                        if (serResultBank.MisaCode != MisaEmun.Scuccess)
                        {
                            return serResultBank;
                        }
                    }
                }
                return serResultEmployee;
            }
        }
        #endregion

        #region filter employee
        public IEnumerable<Employee> SearchEmployeeByKey(string key, long page, long limmit)
        {
            var result = this.GetEmployeeByEmployeeCode(key);
            if(result.Any() == false)
            {
                result = this.GetEmployeesByName(key, page, limmit);
            }
            return result;
        }
        #endregion

        #region delete employee

        public ServiceResult DeleteEmployeeByEmployeeCode(string code)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeeCode");
            values.Add(code);
            return base.DeleteT(fieldNames, values);
        }

        #endregion
    }
}
