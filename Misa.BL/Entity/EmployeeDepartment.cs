using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Entity
{
    /// <summary>
    /// đơn vị nhân viên
    /// </summary>
    public class EmployeeDepartment : BaseEntity
    {
        /// <summary>
        /// id của đơn vị nhân viên
        /// </summary>
        public Guid EmployeeDepartmentId { get; set; }

        /// <summary>
        /// tên đơn vị
        /// </summary>
        public string EmployeeDepartmentName { get; set; }

        /// <summary>
        /// mô tả đơn vị
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// trách nhiệm của đơn vị
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// lợi ích của đơn vị
        /// </summary>
        public string Profit { get; set; }
    }
}
