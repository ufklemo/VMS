using Castle.Windsor;
using System;
using System.Reflection;

namespace VMS.Model.Dependency
{
    public interface IIOCManager
    {
        IWindsorContainer IocContainer { get; }
        void Register<TType, TImp>()
            where TType : class
            where TImp : TType, new();
        void Register<TType, TImp>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Transient)
            where TType : class
            where TImp : TType, new();
        void Register(Type tType, Type tImp);
        void Register(Type tType, Type tImp, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Transient);
        void AddConvention(IDependencyConventional dependencyConventional);
        void RegisterByConvention(Assembly assembly);
    }
}
