using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.BL.Entity;
using Misa.BL.IService.IEmployeeService;
using Misa.BL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA_AMIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAccountBankController : BaseEntityController<EmployeeAccountBank>
    {
        IEmployeeAccountBankService employeeAccountBankService;
        public EmployeeAccountBankController(IEmployeeAccountBankService _employeeAccountBankService) : base(_employeeAccountBankService)
        {
            employeeAccountBankService = _employeeAccountBankService;
        }

        /// <summary>
        /// lấy danh sách tài khoản ngân hàng theo id nhân viên
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// created: Manh Tien(22/2/2021)
        [HttpGet("list/{employeeId}")]
        public IEnumerable<EmployeeAccountBank> GetEmployeeAccountBankList(string employeeId)
        {
            return employeeAccountBankService.GetAccountBanksByEmployeeId(employeeId);
        }

        /// <summary>
        /// xóa tk ngân hàng theo id tài khoản ngân hàng
        /// </summary>
        /// <param name="bankAccountId"></param>
        /// <returns></returns>
        /// created: Manh Tien(22/2/2021)
        [HttpDelete("{bankAccountId}")]
        public ServiceResult DeleteAccountBank(string bankAccountId)
        {
            return employeeAccountBankService.DeleteEmployeeAccountBank(bankAccountId);
        }
    }
}
