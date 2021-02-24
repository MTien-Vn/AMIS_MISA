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

        /// <summary>
        /// xóa tài khoản ngân hàng nhân viên bằng id nhân viên
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>đối tượng serviceResult</returns>
        /// created: ManhTien(22/2/2021)
        public ServiceResult DeleteEmployeeAccountBankByEmployeeId(string employeeId);
        #endregion

        #region filter AccountBank
        /// <summary>
        /// lấy danh sách tài khoản ngân hàng bằng id của nhân viên
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>Danh sách tài khoản ngân hàng</returns>
        /// created: Manh Tien(22/2/2021)
        public IEnumerable<EmployeeAccountBank> GetAccountBanksByEmployeeId(string employeeId);
        #endregion
    }
}
