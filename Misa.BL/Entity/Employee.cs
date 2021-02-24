using Misa.BL.ValidateData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Entity
{
    /// <summary>
    /// thông tin nhân viên
    /// </summary>
    public class Employee : BaseEntity
    {
        /// <summary>
        /// Id nhân viên
        /// </summary>
        public Guid? EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [Required("Mã nhân viên")]
        [CheckDup("Mã nhân viên")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// tên nhân viên
        /// </summary>
        [Required("Họ và tên")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// giới tính: 0-nam; 1-nữ; 2-khác
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// id của đơn vị nhân viên
        /// </summary>
        [Required("Id đơn vị nhân viên")]
        public int EmployeeDepartmentId { get; set; }

        /// <summary>
        /// tên của đơn vị nhân viên
        /// </summary>
        public string EmployeeDepartmentName { get; set; }


        /// <summary>
        /// số CMND/thẻ căn cước công dân
        /// </summary>
        [CheckDup("Số CMND/thẻ căn cước công dân")]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// ngày cấp CMTND/thẻ căn cước công dân
        /// </summary>
        public DateTime IdentityDate { get; set; }

        /// <summary>
        /// nơi cấp
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// vị trí nhân viên
        /// </summary>
        public string EmployeePosition { get; set; }

        /// <summary>
        /// địa chỉ nhân viên
        /// </summary>
        public string EmployeeAdress { get; set; }

        /// <summary>
        /// điện thoại di động
        /// </summary>
        [CheckDup("Điện thoại di động")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// số cố định
        /// </summary>
        public string TeleNumber { get; set; }

        /// <summary>
        /// email nhân viên
        /// </summary>
        [CheckDup("email nhân viên")]
        public string Email { get; set; }

        /// <summary>
        /// id số tài khoản
        /// </summary>
        public Guid? EmployeeAccountId { get; set; }

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
        /// trạng thái tài khoản ngân hàng nhân viên, 0-ngưng hđ; 1-hoạt động
        /// </summary>
        public int StateAccount { get; set; }
    }
}
