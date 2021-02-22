using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.BL.Entity
{
    public class BaseEntity
    {
        /// <summary>
        /// người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// người sửa
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// ngày sửa
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
