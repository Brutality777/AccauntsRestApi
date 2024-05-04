using Account.Contracts.Commands;
using Account.Service.Domain.DataModels;
using AutoMapper;

namespace Account.Service.Application
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddAccountCommand, AccountDataModel>().ReverseMap();
        }
    }
}
