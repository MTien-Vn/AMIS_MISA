using Misa.BL.ValidateData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Entity
{
    /// <summary>
    /// tài khoản ngân hàng nhân viên
    /// </summary>
    public class EmployeeAccountBank : BaseEntity
    {
        /// <summary>
        /// id số tài khoản
        /// </summary>
        public Guid EmployeeAccountId { get; set; }

        /// <summary>
        /// số tài khoản ngân hàng của nhân viên
        /// </summary>
        public string EmployeeAccountNumber { get; set; }

        /// <summary>
        /// tên ngân hàng
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// tên chi nhánh ngân hàng
        /// </summary>
        public string BranchName { get; set; }

        /// <summary>
        /// tên tỉnh/thành phố của nhân hàng
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// id nhân viên sử dụng tài khoản ngân hàng
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// trạng thái tài khoản ngân hàng nhân viên, 0-ngưng hđ; 1-hoạt động
        /// </summary>
        public int StateAccount { get; set; }
    }
}
