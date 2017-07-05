using System;
using VMS.Model.Dependency;

namespace VMS.Model
{
    public class Saver : ISaver,ITransientDependency
    {
        public void SaveData()
        {
            Console.WriteLine("Begin Save Option");
        }
    }
}
