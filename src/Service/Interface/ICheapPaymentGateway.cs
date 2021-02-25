using System.Threading.Tasks;
using filedChallenge.Models.Request;
using filedChallenge.Models.Response;

namespace filedChallenge.Service.Interface
{
    public interface ICheapPaymentGateway
    {
         Task<ServiceResponse> CheapPayment(PaymentRequestModel model);
    }
}