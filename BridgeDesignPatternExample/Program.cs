using System;

namespace BridgeDesignPatternStructure
{

    /// <summary> 
    /// Implimentor Interface - LED TV
    /// </summary>
    public interface LEDTV
    {
        void SwitchOn();
        void SwitchOff();
        void SetChannel(int channelNumber);
    }

    /// <summary>
    /// Abstration - Remote
    /// </summary>
    public abstract class AbstractRemoteControl
    {
        protected LEDTV ledTv;

        protected AbstractRemoteControl(LEDTV ledTv)
        {
            this.ledTv = ledTv;
        }

        public abstract void SwitchOn();
        public abstract void SwitchOff();
        public abstract void SetChannel(int channelNumber);
    }

    //----------------------------------------------------------------------------------------

    /// <summary>
    /// Concrete Implementor 1
    /// </summary>
    public class SamsungLedTv : LEDTV
    {
        public void SwitchOn()
        {
            Console.WriteLine("Turning ON : Samsung TV");
        }
        public void SwitchOff()
        {
            Console.WriteLine("Turning OFF : Samsung TV");
        }

        public void SetChannel(int channelNumber)
        {
            Console.WriteLine("Setting channel Number " + channelNumber + " on Samsung TV");
        }
    }

    /// <summary>
    /// Concrete Implementor 2
    /// </summary>
    public class SonyLedTv : LEDTV
    {
        public void SwitchOn()
        {
            Console.WriteLine("Turning ON : Sony TV");
        }
        public void SwitchOff()
        {
            Console.WriteLine("Turning OFF : Sony TV");
        }

        public void SetChannel(int channelNumber)
        {
            Console.WriteLine("Setting channel Number " + channelNumber + " on Sony TV");
        }
    }

    /// <summary>
    /// Refined Abstraction 
    /// </summary>
    public class RemoteControl : AbstractRemoteControl
    {
        public RemoteControl(LEDTV ledTv) : base(ledTv)
        {
        }

        public override void SwitchOn()
        {
            ledTv.SwitchOn();
        }

        public override void SwitchOff()
        {
            ledTv.SwitchOff();
        }

        public override void SetChannel(int channelNumber)
        {
            ledTv.SetChannel(channelNumber);
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            //Sony Remote
             AbstractRemoteControl sonyRemoteControl = new RemoteControl(new SonyLedTv());
            sonyRemoteControl.SwitchOn();
            sonyRemoteControl.SetChannel(101);
            sonyRemoteControl.SwitchOff();


            //Samsung Remote
            AbstractRemoteControl samsungRemoteControl = new RemoteControl(new SonyLedTv());
            samsungRemoteControl.SwitchOn();
            samsungRemoteControl.SetChannel(202);
            samsungRemoteControl.SwitchOff();

            Console.ReadKey();
        }
    }
}
