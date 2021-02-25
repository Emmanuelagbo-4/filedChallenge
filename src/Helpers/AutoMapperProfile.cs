using AutoMapper;
using filedChallenge.Entities;
using filedChallenge.Models.Request;
using filedChallenge.Models.Response;

namespace filedChallenge.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Payment, PaymentRequestModel>().ReverseMap();
            CreateMap<Payment, PaymentResponseModel>().ReverseMap();
            CreateMap<PaymentState, PaymentStateResponseModel>().ReverseMap();
        }
    }
}