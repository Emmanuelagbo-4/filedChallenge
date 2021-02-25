using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace filedChallenge.Entities
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public string CreditCardNumber {get; set;}
        public string CardHolder {get; set;}
        public string SecurityCode {get; set;}
        public decimal Amount {get; set;}
        public int PaymentStateId {get; set;}
        [ForeignKey("PaymentStateId")]
        public PaymentState PaymentState {get; set;}

    }
}