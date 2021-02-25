namespace filedChallenge.Models.Response
{
    public class PaymentResponseModel
    {
        public int Id {get; set;}
        public string CreditCardNumber {get; set;}
        public string CardHolder {get; set;}
        public string SecurityCode {get; set;}
        public decimal Amount {get; set;}
        public PaymentStateResponseModel PaymentStateResponseModel {get; set;}
    }
}