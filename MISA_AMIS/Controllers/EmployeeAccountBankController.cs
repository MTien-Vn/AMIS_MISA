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

        [HttpDelete("{bankAccountId}")]
        public ServiceResult DeleteAccountBank(string bankAccountId)
        {
            return employeeAccountBankService.DeleteEmployeeAccountBank(bankAccountId);
        }
    }
}
