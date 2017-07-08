using VMS.Console.AutoMapperTest;
using VMS.Model;
using VMS.Model.Dependency;

namespace VMS.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var boot = VMSBootStrap.Create(typeof(ConsoleModule));
            boot.Initialize();
            AutoMapperConfig.Initial();
            MapperTest.MapDTOs();
            var processer = IOCManager.Instance.Resolve<IVMSProcesser>();
            processer.ProcessVMS();
            System.Console.ReadKey();
        }
    }
}
