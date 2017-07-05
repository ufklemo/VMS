namespace VMS.Model
{
    public interface IReceiver
    {
        //Queue<string> GPSs { get; set; }
        void Receive();
    }
}
