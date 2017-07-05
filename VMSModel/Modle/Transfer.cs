using System;
using VMS.Model.Dependency;

namespace VMS.Model
{
    public class Transfer : ITransfer, ITransientDependency
    {
        public void TransferData()
        {
            Console.WriteLine("Bein Transfer Data");
        }
    }
}
