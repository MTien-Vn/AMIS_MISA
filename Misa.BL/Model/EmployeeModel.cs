using Misa.BL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Model
{
    public class EmployeeModel
    {
        /// <summary>
        /// nhân viên
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// danh sách tài khoản ngân hàng
        /// </summary>
        public List<EmployeeAccountBank> EmployeeAccountBanks { get; set; }
    }
}
