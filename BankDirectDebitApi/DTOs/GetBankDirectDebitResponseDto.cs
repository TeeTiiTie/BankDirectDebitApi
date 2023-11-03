namespace BankDirectDebitApi.DTOs
{
    public class GetBankDirectDebitResponseDto
    {
        public int? BankDirectDebitId { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string BankShortName { get; set; }
        public string BankCode { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public int? BankDirectDebitStatusId { get; set; }
        public string BankDirectDebitStatusDisplay { get; set; }
    }
}