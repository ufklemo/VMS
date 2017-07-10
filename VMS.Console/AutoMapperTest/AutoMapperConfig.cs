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
            //有用的地方：将Type作为参数传入，与将Type作为泛型，两者的区别和实现。            
            //问题：此种方案都加载了一次映射关系
            //Mapper.Initialize(cfg => cfg.AddProfiles(profiles));
            //问题：此种方案会导致只能加载最后一个映射关系
            //foreach (var profile in profiles)
            //{
            //    Mapper.Initialize(cfg =>
            //    {
            //        cfg.AddProfile(profile);
            //    });
            //}
            //Type 和 Class不一样，所以Type不能作为泛型参数，使用cfg.AddProfile<profile>();
            Mapper.Initialize(cfg =>
                    {
                        foreach (var profile in profiles)
                            cfg.AddProfile(profile);
                    });
        }
    }
}
