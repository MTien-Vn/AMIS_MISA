﻿using Misa.BL.Entity;
using Misa.BL.Interface.IRepository;
using Misa.BL.Interface.IRepository.IEmployeeRepository;
using Misa.BL.IService.IEmployeeService;
using Misa.BL.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.ServiceImp.EmployeeServiceImp
{
    public class EmployeeAccountBankServiceImp : BaseServiceImp<EmployeeAccountBank>, IEmployeeAccountBankService
    {
        IEmployeeAccountBankRepository employeeAccountBankRepository;
        public EmployeeAccountBankServiceImp(IEmployeeAccountBankRepository _employeeAccountBankRepository) : base(_employeeAccountBankRepository)
        {
            employeeAccountBankRepository = _employeeAccountBankRepository;
        }
        #region delete employeeBank
        public ServiceResult DeleteEmployeeAccountBank(string id)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeeAccountId");
            values.Add(id);
            return base.DeleteT(fieldNames, values);
        }

        public ServiceResult DeleteEmployeeAccountBankByEmployeeId(string employeeId)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeeId");
            values.Add(employeeId);
            return base.DeleteT(fieldNames, values);
        }

        #endregion

        #region filter employeeBank

        public IEnumerable<EmployeeAccountBank> GetAccountBanksByEmployeeId(string employeeId)
        {
            List<string> fieldNames = new List<string>();
            List<string> values = new List<string>();
            fieldNames.Add("EmployeeId");
            values.Add(employeeId);
            return employeeAccountBankRepository.GetData(0, 0, fieldNames, values);
        }

        #endregion
    }
}
