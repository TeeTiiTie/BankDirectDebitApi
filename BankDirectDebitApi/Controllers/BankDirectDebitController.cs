using BankDirectDebitApi.DTOs;
using BankDirectDebitApi.Models;
using BankDirectDebitApi.Services.BankDirectDebit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BankDirectDebitApi.Controllers
{
    //[Authorize]
    [Route("api")]
    [ApiController]
    public class BankDirectDebitController : ControllerBase
    {
        private readonly IBankDirectDebitServices _services;

        public BankDirectDebitController(IBankDirectDebitServices services)
        {
            _services = services;
        }

        [HttpGet("bankdirectdebit", Name = "BankDirectDebit")]
        public async Task<ServiceResponse<List<GetBankDirectDebitResponseDto>>> GetBankDirectDebit([FromQuery] GetBankDirectDebitRequestDto requestDto)
        {
            try
            {
                var response = await _services.GetBankDirectDebit(requestDto);
                return ResponseResult.Success(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error GetBankDirectDebit");
                return ResponseResult.Failure<List<GetBankDirectDebitResponseDto>>("Error GetBankDirectDebit");
            }
        }
    }
}