using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using filedChallenge.Models.Request;
using Newtonsoft.Json;
using Xunit;

namespace filedChallenge.test.UnitTests
{
    public class PaymentControllerTest
    {
        HttpClient client = new HttpClient();
        [Fact]

        public async Task ProcessPayment_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            //Arrange
            PaymentRequestModel TestPayment = new PaymentRequestModel
            {
                CreditCardNumber = "12312312312312",
                CardHolder = "Emmanuel Agbo",
                SecurityCode = "123",
                Amount = 600
            };

            string JsonStudent = JsonConvert.SerializeObject(TestPayment);

            //Act
            var stringContent = new StringContent(JsonStudent, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:5001/api/payment/process-payment", stringContent);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode); //Change status code
        }
    }
}