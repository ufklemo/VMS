using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using System.Reflection;

namespace VMS.Model.Dependency
{
    public class BasicDependencyConventional : IDependencyConventional
    {
        public IIOCManager _ioc { get; set; }

        public void RegisterAssembly(Assembly assembly)
        {
            //Transient
            _ioc.IocContainer.Register(
                Classes.FromAssembly(assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<ITransientDependency>()
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient()
                );

            //Singleton
            _ioc.IocContainer.Register(
                Classes.FromAssembly(assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<ISingletonDependency>()
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleSingleton()
                );

            //Windsor Interceptors
            _ioc.IocContainer.Register(
                Classes.FromAssembly(assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<IInterceptor>()
                    .WithService.Self()
                    .LifestyleTransient()
                );
        }
    }
}
