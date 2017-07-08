using AutoMapper;
using VMS.Console.AutoMapperTest.AccountManagement.DTO;
using VMS.Console.AutoMapperTest.AccountManagement.Entity;
using VMS.Console.Extensions;

namespace VMS.Console.AutoMapperTest.OrderManagement
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDTO>()
                .ForMember(d => d.CreateDateTime, x => x.MapFrom(s => s.CreateDateTime.ToDateTimeFromUnixTime()));
        }
    }
}
