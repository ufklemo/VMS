using AutoMapper;
using VMS.Console.AutoMapperTest.OrderManagement.DTO;
using VMS.Console.AutoMapperTest.OrderManagement.Entity;

namespace VMS.Console.AutoMapperTest.OrderManagement
{
    class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDTO, Order>()
                .ForMember(d => d.Id, x => x.Ignore());
        }
    }
}
