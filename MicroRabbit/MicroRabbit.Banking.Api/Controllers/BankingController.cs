using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Banking.Api.Controllers
{
    [Route("api/Banking")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private IAccountService _accountService;

        public BankingController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("accounts")]
        public IEnumerable<Account> GetAll()
        {
            return _accountService.GetAll();
        }

        [HttpPost("accounts")]
        public void Save([FromBody] Account account)
        {
            _accountService.Save(account);
        }

        [HttpPost("transfers")]
        public void Transfer([FromBody] AccountTransfer accountTransfer)
        {
            _accountService.Transfer(accountTransfer);
        }
    }
}
