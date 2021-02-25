using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using filedChallenge.Data;
using filedChallenge.Entities;
using filedChallenge.Models.Request;
using filedChallenge.Models.Response;
using filedChallenge.Service.Interface;
using filedChallenge.Utility;
using Microsoft.EntityFrameworkCore;

namespace filedChallenge.Service.Repository
{
    public class PaymentService : IExpensivePaymentGateway, ICheapPaymentGateway
    {
        ApplicationDbContext _dbContext;
        IMapper _mapper;
        public PaymentService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse> CheapPayment(PaymentRequestModel model)
        {
            decimal UserCreditCardBalance = 10;
            if (model.Amount > UserCreditCardBalance)
            {
                var resp = await GetfailedPayment(model);
                return new ServiceResponse { data = resp.data, response = "Cheap Payment failed, Insufficient Balance", status = false };
            }
            var response = await GetProcessedPayment(model);
            return new ServiceResponse { data = response.data, response = "Cheap Payment is being Processed", status = true };
        }

        public async Task<ServiceResponse> ExpensivePayment(PaymentRequestModel model)
        {
            decimal UserCreditCardBalance = 500;
            if (model.Amount > UserCreditCardBalance)
            {
                var resp = await GetfailedPayment(model);
                return new ServiceResponse { data = resp.data, response = "Expensive Payment failed, Insufficient Balance", status = false };
            }
            var response = await GetProcessedPayment(model);
            return new ServiceResponse { data = response.data, response = "Expensive Payment is being Processed", status = true };
        }

        public async Task<ServiceResponse> PremiumPayment(PaymentRequestModel model)
        {
            decimal UserCreditCardBalance = 1000;
            if (model.Amount > UserCreditCardBalance)
            {
                var resp = await GetfailedPayment(model);
                return new ServiceResponse { data = resp.data, response = "Premium Payment failed, Insufficient Balance", status = false };
            }
            var response = await GetProcessedPayment(model);
            return new ServiceResponse { data = response.data, response = "Premium Payment is being Processed", status = true };
        }

        public async Task<ServiceResponse> ProcessPayment(PaymentRequestModel model)
        {
            var response = new ServiceResponse();
            if (model.Amount < 20)
            {
                response = await CheapPayment(model);
            }
            else if (model.Amount > 20 && model.Amount <= 500)
            {
                bool IsExpensivePaymentAvailable = true;
                if (IsExpensivePaymentAvailable == true)
                {
                    response = await ExpensivePayment(model);
                }
                else
                {
                    int count = 0;
                    while (count < 1)
                    {
                        response = await CheapPayment(model);
                    }
                }
            }
            else if (model.Amount > 500)
            {
                bool IstransactionFailed = true;
                int count = 0;

                     
                 while (count < 3 && IstransactionFailed == true){
                     response = await PremiumPayment(model);  
                     count ++;
                 };
               
            }

            return new ServiceResponse { data = response.data, status = response.status, response = response.response };
        }

        public async Task<ServiceResponse> GetProcessedPayment(PaymentRequestModel model)
        {
            var PaymentStatusObj = new PaymentState();
            PaymentStatusObj.PaymentStatus = PaymentStatuses.Processing;
            var PaymentStatesEntity = (await _dbContext.PaymentStates.AddAsync(PaymentStatusObj)).Entity;
            await _dbContext.SaveChangesAsync();

            var PaymentModel = _mapper.Map<Payment>(model);
            PaymentModel.PaymentStateId = PaymentStatesEntity.Id;
            var Entity = (await _dbContext.Payments.AddAsync(PaymentModel)).Entity;
            await _dbContext.SaveChangesAsync();

            var SuccessfulPaymentModel = _dbContext.Payments.Where(x => x.Id == Entity.Id).Include(x => x.PaymentState).FirstOrDefault();

            var data = _mapper.Map<PaymentResponseModel>(SuccessfulPaymentModel);
            data.PaymentStateResponseModel = _mapper.Map<PaymentStateResponseModel>(PaymentStatesEntity);
            return new ServiceResponse { data = data, status = true };
        }

        public async Task<ServiceResponse> GetfailedPayment(PaymentRequestModel model)
        {
            var PaymentStatusObj = new PaymentState();
            PaymentStatusObj.PaymentStatus = PaymentStatuses.Failed;
            var PaymentStatesEntity = (await _dbContext.PaymentStates.AddAsync(PaymentStatusObj)).Entity;
            await _dbContext.SaveChangesAsync();

            var PaymentModel = _mapper.Map<Payment>(model);
            PaymentModel.PaymentStateId = PaymentStatesEntity.Id;
            var Entity = (await _dbContext.Payments.AddAsync(PaymentModel)).Entity;
            await _dbContext.SaveChangesAsync();

            var FailedPaymentModel = _dbContext.Payments.Where(x => x.Id == Entity.Id).Include(x => x.PaymentState).FirstOrDefault();

            var data = _mapper.Map<PaymentResponseModel>(FailedPaymentModel);
            data.PaymentStateResponseModel = _mapper.Map<PaymentStateResponseModel>(PaymentStatesEntity);
            return new ServiceResponse { data = data, status = true };
        }
    }
}