using System.ComponentModel.DataAnnotations;

namespace filedChallenge.Models.Request
{
    public class PaymentRequestModel
    {
        [Required]
        [DataType(DataType.CreditCard)]
        public string CreditCardNumber {get; set;}
        [Required]
        public string CardHolder {get; set;}
        [MaxLength(3)]
        public string SecurityCode {get; set;}
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public decimal Amount {get; set;}
    }
}