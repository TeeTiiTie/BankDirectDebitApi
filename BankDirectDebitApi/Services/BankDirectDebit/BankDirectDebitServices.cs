using BankDirectDebitApi.Data;
using BankDirectDebitApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BankDirectDebitApi.Services.BankDirectDebit
{
    public class BankDirectDebitServices : IBankDirectDebitServices
    {
        private readonly AppDBContext _context;

        public BankDirectDebitServices(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<GetBankDirectDebitResponseDto>> GetBankDirectDebit(GetBankDirectDebitRequestDto requestDto)
        {
            var qry = _context.BankDirectDebit.Where(x => x.IsActive == true)
                                              .Join(_context.BankDirectDebitStatus,
                                                    b => b.BankDirectDebitStatusId,
                                                    bs => bs.BankDirectDebitStatusId,
                                                    (b, bs) => new { b, bs })
                                              .Join(_context.vw_Bank,
                                                    f => f.b.BankId,
                                                    v => v.OrganizeCode,
                                                    (f, v) => new { bdb = f.b, bs = f.bs, v });

            if (requestDto.BankDirectDebitId.HasValue)
                qry = qry.Where(x => x.bdb.BankDirectDebitId == requestDto.BankDirectDebitId);

            if (!string.IsNullOrWhiteSpace(requestDto.AccountNo))
                qry = qry.Where(x => x.bdb.AccountNo == requestDto.AccountNo);

            var qryList = await qry.ToListAsync();

            List<GetBankDirectDebitResponseDto> response = new();

            foreach (var i in qryList)
            {
                GetBankDirectDebitResponseDto dto = new()
                {
                    BankDirectDebitId = i.bdb.BankDirectDebitId,
                    BankId = i.v.BankId,
                    BankName = i.v.BankName,
                    BankShortName = i.v.BankShortName,
                    BankCode = i.v.BankCode,
                    AccountNo = i.bdb.AccountNo,
                    AccountName = i.bdb.AccountName,
                    BankDirectDebitStatusId = i.bdb.BankDirectDebitStatusId,
                    BankDirectDebitStatusDisplay = i.bs.BankDirectDebitStatusDisplay
                };
                response.Add(dto);
            }

            return response;
        }
    }
}