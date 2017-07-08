using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.Console.AutoMapperTest.AccountManagement.DTO;
using VMS.Console.AutoMapperTest.AccountManagement.Entity;
using VMS.Console.AutoMapperTest.OrderManagement.DTO;
using VMS.Console.AutoMapperTest.OrderManagement.Entity;
using VMS.Console.Extensions;

namespace VMS.Console.AutoMapperTest
{
    public class MapperTest
    {
        public static void MapDTOs()
        {
            var account = new Account() { Code = "Test", CreateDateTime = DateTime.Now.ToUnixTime() };
            var accountDTO = Mapper.Map<AccountDTO>(account);
            var orderDTO = new OrderDTO() { CustomerName = "Me", Id = 1000 };
            var order = Mapper.Map<Order>(orderDTO);
        }
    }
}
