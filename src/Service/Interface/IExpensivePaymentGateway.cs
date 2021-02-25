using System.Threading.Tasks;
using filedChallenge.Models.Request;
using filedChallenge.Models.Response;

namespace filedChallenge.Service.Interface
{
    public interface IExpensivePaymentGateway
    {
         Task<ServiceResponse> ExpensivePayment(PaymentRequestModel model);
    }
}