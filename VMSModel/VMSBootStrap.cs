using System;
using System.Reflection;
using VMS.Model.Dependency;

namespace VMS.Model
{
    public class VMSBootStrap : IDisposable
    {
        /// <summary>
        /// Is this object disposed before?
        /// </summary>
        protected bool IsDisposed;
        public IIOCManager IOC { get; private set; }
        public Type StartupModule { get; private set; }
        private static object _lock = new object();
        private VMSBootStrap(Type startModule)
        {
            IOC = IOCManager.Instance;
            StartupModule = startModule;
        }
        private static VMSBootStrap instance;
        public static VMSBootStrap Create(Type startModule)
        {
            if (instance != null)
            {
                return instance;
            }
            //instance初始化之前为Null,lock不能作用于Null值对象
            //lock (instance)       
            lock (_lock)
            {
                instance = new VMSBootStrap(startModule);
            }
            return instance;
        }

        public void Initialize()
        {
            IOC.AddConvention(new BasicDependencyConventional());
            IOC.RegisterByConvention(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Disposes the system.
        /// </summary>
        public virtual void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            IsDisposed = true;

            //_moduleManager?.ShutdownModules();
        }
    }
}
