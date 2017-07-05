using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private VMSBootStrap(Type startModule)
        {
            IOC = IOCManager.Instance;
            StartupModule = startModule;
        }
        private static VMSBootStrap instance;
        public VMSBootStrap Create(Type startModule)
        {
            if (instance != null)
            {
                return instance;
            }
            lock (instance)
            {
                instance = new VMSBootStrap(startModule);
            }
            return instance;
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
