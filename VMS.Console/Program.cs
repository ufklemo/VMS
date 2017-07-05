using Castle.MicroKernel.Registration;
using System;
using VMS.Model;

namespace VMS.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            AppBoot();
            var processer = IOC.Instance.container.Resolve<IVMSProcesser>();
            IOC.Instance.container.Release(processer);
            processer.ProcessVMS();
            System.Console.ReadKey();
        }

        private static void AppBoot()
        {
            System.Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssFFF"));
            IOC.Instance.container.Register(Component.For(typeof(ITCPReceiver), typeof(TCPReceiver)).ImplementedBy(typeof(TCPReceiver)).LifestyleSingleton());
            IOC.Instance.container.Register(Component.For(typeof(ISaver), typeof(Saver)).ImplementedBy(typeof(Saver)).LifestyleSingleton());
            IOC.Instance.container.Register(Component.For(typeof(ITransfer), typeof(Transfer)).ImplementedBy(typeof(Transfer)).LifestyleSingleton());
            IOC.Instance.container.Register(Component.For(typeof(IVMSProcesser), typeof(ProjVMSProcesser)).ImplementedBy(typeof(ProjVMSProcesser)).LifestyleSingleton());
            System.Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssFFF"));
        }
    }
}
