using Misa.BL.Entity;
using Misa.BL.Interface.IService;
using Misa.BL.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.IService.IEmployeeService
{
    public interface IEmployeeAccountBankService : IBaseService<EmployeeAccountBank>
    {
        #region delete employeeAccountBank
        /// <summary>
        /// xóa tài khoản ngân hàng nhân viên bằng id số tài khoản
        /// </summary>
        /// <param name="id"></param>
        /// <returns>đối tượng serviceResult</returns>
        /// created: ManhTien(22/2/2021)
        public ServiceResult DeleteEmployeeAccountBank(string id);
        #endregion
    }
}
