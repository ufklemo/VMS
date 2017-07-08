using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VMS.Console.AutoMapperTest
{
    public class AutoMapperConfig
    {
        public static void Initial()
        {
            var profiles = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(Profile).IsAssignableFrom(t));
            //问题：第一种方案多加载了一次映射关系，第二种方案多加载了三次映射关系
            //有用的地方：将Type作为参数传入，与将Type作为泛型，两者的区别和实现。
            //Mapper.Initialize(cfg => cfg.AddProfiles(profiles));
            Mapper.Initialize(cfg =>
            {
                foreach (var profile in profiles)
                    cfg.AddProfiles(profiles);
            });
            //foreach (var profile in profiles)
            //    Mapper.Initialize(cfg =>
            //    {
            //        //cfg.AddProfile<Profiles.OrderProfile>();
            //        //cfg.AddProfile<Profiles.CalendarEventProfile>();
            //    });
        }
    }
}
