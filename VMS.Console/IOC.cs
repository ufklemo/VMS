using Castle.Windsor;

namespace VMS.Console
{
    public class IOC
    {
        public IWindsorContainer container { get; set; }
        private IOC()
        {
            container = new WindsorContainer();
        }

        static public readonly IOC Instance = new IOC();
    }
}
