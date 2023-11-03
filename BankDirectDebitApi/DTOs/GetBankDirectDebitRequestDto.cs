using System.ComponentModel.DataAnnotations;

namespace BankDirectDebitApi.DTOs
{
    public class GetBankDirectDebitRequestDto : IValidatableObject
    {
        public int? BankDirectDebitId { get; set; }
        public string? AccountNo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!BankDirectDebitId.HasValue && string.IsNullOrWhiteSpace(AccountNo))
                yield return new ValidationResult("Request is null");
        }
    }
}