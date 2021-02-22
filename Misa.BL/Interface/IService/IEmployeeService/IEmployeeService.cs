using Misa.BL.Entity;
using Misa.BL.Service;
using System.Collections.Generic;

namespace Misa.BL.Interface.IService.IEmployeeService
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        #region save employee
        /// <summary>
        /// lưu thông tin nhân viên ( dùng cho cả save và update)
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="employeeAccountBank"></param>
        /// createdBy: ManhTien(22/2/2021)
        /// <returns>đối tượng ServiceResult</returns>
        ServiceResult SaveEmployee(Employee employee, List<EmployeeAccountBank> employeeAccountBank);
        #endregion
        #region get employee
        /// <summary>
        /// lấy thông tin nhân vienen bằng mã nhân viên
        /// </summary>
        /// <param name="code"></param>
        /// <returns>thông tin nhân viên</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        IEnumerable<Employee> GetEmployeeByEmployeeCode(string code);

        /// <summary>
        /// kiểm tra sự tồn tại của số điện thoại
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>true-đã tồn tại/ false-chưa tồn tại</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        IEnumerable<Employee> GetEmployeeByPhoneNumber(string phoneNumber);

        /// <summary>
        /// kiểm tra sự tồn tại của email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true-đã tồn tại/ false-chưa tồn tại</returns>
        /// CreadtedBy: Mạnh Tiến(25/12/2020)
        IEnumerable<Employee> GetEmployeeByEmail(string email);

        /// <summary>
        /// lấy thông tinh nhân viên bằng tên
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <returns>danh sách nhân viên</returns>
        /// <returns>thông tin của nhân viên</returns>
        /// createdBy: Mạnh Tiến(26/12/2020)
        IEnumerable<Employee> GetEmployeesByName(string name, long page, long limmit);

        /// <summary>
        /// lấy danh sách nhân viên bằng bộ phận có phân trang
        /// </summary>
        /// <param name="employeeDepartmentId"></param>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <returns>danh sách các nhân viên</returns>
        /// createdBy: Mạnh Tiến(27/12/2020)
        IEnumerable<Employee> GetEmployeesByEmployeeDepartment(string employeeDepartmentId, long page, long limmit);

        /// <summary>
        /// lấy danh sách nhân viên bằng vị trí của nhân viên và bộ phận có phân trang
        /// </summary>
        /// <param name="employeePositionId"></param>
        ///  <param name="employeeDepartmentId"></param>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <returns>danh sách các nhân viên</returns>
        /// createdBy: Mạnh Tiến(27/12/2020)

        /// <summary>
        /// lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>mã lớn nhất</returns>
        /// createdBy: Mạnh Tiến(3/1/2020)
        string GetEmployeeCodeMax();
        #endregion

        #region filter employee
        /// <summary>
        /// lấy danh sách nhân viên bằng từ khóa
        /// </summary>
        ///  <param name="key"></param>
        /// <param name="page"></param>
        /// <param name="limmit"></param>
        /// <returns>danh sách các nhân viên</returns>
        /// createdBy: Mạnh Tiến(27/12/2020)
        IEnumerable<Employee> SearchEmployeeByKey(string key, long page, long limmit);
        #endregion

        #region count employee
        /// <summary>
        /// lấy số lượng nhân viên bằng từ khóa
        /// </summary>
        ///  <param name="key"></param>
        /// <returns>số lượng: long</returns>
        /// createdBy: Mạnh Tiến(27/12/2020)
        long CountEmployeeByKey(string key);
        #endregion

        #region delete employee
        /// <summary>
        /// xóa nhân viên bằng mã nhân viên
        /// </summary>
        /// <param name="code"></param>
        /// <returns>đối tượng serviceResult</returns>
        /// created: ManhTien(22/2/2021)
        public ServiceResult DeleteEmployeeByEmployeeCode(string code);
        #endregion
    }
}
