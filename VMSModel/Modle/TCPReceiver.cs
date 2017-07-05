using System;
using VMS.Model.Dependency;

namespace VMS.Model
{
    public class TCPReceiver : ITCPReceiver, ITransientDependency
    {
        public void Receive()
        {
            Console.WriteLine("TCPReceiver is open");
        }
    }
}
