using VMS.Model.Dependency;

namespace VMS.Model
{
    public class ProjVMSProcesser : VMSProcesser, ISingletonDependency
    {
        public ProjVMSProcesser(ITCPReceiver receiver, ISaver saver, ITransfer transfer)
            : base(receiver, saver, transfer)
        { }
    }
}
