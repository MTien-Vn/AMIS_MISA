using Misa.BL.Enum;
using System.Collections.Generic;

namespace Misa.BL.Service
{
    /// <summary>
    /// đối tượng quản lý dữ liệu trả về sau khi thao tác db
    /// </summary>
    public class ServiceResult
    {
        public object Data { get; set; }

        /// <summary>
        /// Danh sách thông báo trả về
        /// </summary>
        public List<string> Messenger { get; set; } = new List<string>();

        /// <summary>
        /// mã thông báo lỗi
        /// </summary>
        public MisaEmun MisaCode { get; set; }
    }
}
