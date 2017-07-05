using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace VMS.Model.Dependency
{
    public class IOCManager : IIOCManager
    {
        public IWindsorContainer IocContainer { get; private set; }

        private List<IDependencyConventional> _dependencyConventionals;

        public static readonly IOCManager Instance = new IOCManager();

        private IOCManager()
        {
            IocContainer = new WindsorContainer();
            _dependencyConventionals = new List<IDependencyConventional>();

            //Register self!
            IocContainer.Register(
                Component.For<IOCManager, IIOCManager>().UsingFactoryMethod(() => this)
                );
        }

        public void AddConvention(IDependencyConventional dependencyConventional)
        {
            _dependencyConventionals.Add(dependencyConventional);
        }

        public void Register<TType, TImp>()
            where TType : class
            where TImp : TType, new()
        {
            Register<TType, TImp>(DependencyLifeStyle.Transient);
        }

        public void Register<TType, TImp>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Transient)
            where TType : class
            where TImp : TType, new()
        {
            var registration = Component.For<TType, TImp>().ImplementedBy<TImp>().UseLifeStyle(lifeStyle);
            IocContainer.Register(registration);
        }

        public void Register(Type tType, Type tImp)
        {
            Register(tType, tImp, DependencyLifeStyle.Transient);
        }

        public void Register(Type tType, Type tImp, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Transient)
        {
            var registration = Component.For(tType, tImp).ImplementedBy(tImp).UseLifeStyle(lifeStyle);
            IocContainer.Register(registration);
        }

        public void RegisterByConvention(Assembly assembly)
        {
            foreach (var conventional in _dependencyConventionals)
            {
                conventional._ioc = this;
                conventional.RegisterAssembly(assembly);
            }
        }

        public T Resolve<T>()
        {
            return IocContainer.Resolve<T>();
        }
    }
}
