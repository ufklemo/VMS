using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.Model.Dependency
{
    public static class IOCExtension
    {
        public static ComponentRegistration<TService> UseLifeStyle<TService>(this ComponentRegistration<TService> reg, DependencyLifeStyle lifeStyle)
            where TService : class
        {
            if (lifeStyle == DependencyLifeStyle.Transient)
                reg = reg.LifestyleTransient();
            else
                reg = reg.LifestyleSingleton();
            return reg;
        }
    }
}
