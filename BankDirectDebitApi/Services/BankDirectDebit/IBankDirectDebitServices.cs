using BankDirectDebitApi.DTOs;

namespace BankDirectDebitApi.Services.BankDirectDebit
{
    public interface IBankDirectDebitServices
    {
        Task<List<GetBankDirectDebitResponseDto>> GetBankDirectDebit(GetBankDirectDebitRequestDto requestDto);
    }
}