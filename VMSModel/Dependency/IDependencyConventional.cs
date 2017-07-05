using System.Reflection;

namespace VMS.Model.Dependency
{
    public interface IDependencyConventional
    {
        IIOCManager _ioc { get; set; }
        void RegisterAssembly(Assembly assembly);
    }
}
