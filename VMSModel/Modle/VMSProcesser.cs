namespace VMS.Model
{
    public abstract class VMSProcesser : IVMSProcesser
    {
        IReceiver _receiver { get; set; }
        ISaver _saver { get; set; }
        ITransfer _transfer { get; set; }
        public VMSProcesser(IReceiver receiver, ISaver saver, ITransfer transfer)
        {
            _receiver = receiver;
            _saver = saver;
            _transfer = transfer;
        }
        public virtual void ProcessVMS()
        {
            _receiver.Receive();
            _transfer.TransferData();
            _saver.SaveData();
        }
    }
}
