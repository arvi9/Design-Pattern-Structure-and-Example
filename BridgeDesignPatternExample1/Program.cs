using System;

namespace BridgeDesignPatternExample1
{
    /// <summary>
    /// Abstraction - Switch
    /// </summary>
    public abstract class ISwitch
    {
        protected IEquipment equipment;
        protected ISwitch(IEquipment equipment)
        {
            this.equipment = equipment;
        }
        public abstract void On();
        public abstract void Off();
    }

    /// <summary>
    /// Implementor - All electrical equipment has Switch
    /// </summary>
    public interface IEquipment
    {
        void Start();
        void Stop();
    }

//----------------------------------------------------------------------------------

    class TV : IEquipment
    {
        public void Start()
        {
            Console.WriteLine("Starting TV");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping TV");
        }
    }

    class Fan : IEquipment
    {
        public void Start()
        {
            Console.WriteLine("Starting Fan");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping Fan");
        }
    }

    class Radio : IEquipment
    {
        public void Start()
        {
            Console.WriteLine("Starting Radio");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping Radio");
        }
    }

    class Computer : IEquipment
    {
        public void Start()
        {
            Console.WriteLine("Starting Computer");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping Computer");
        }
    }


    public class ElectricalSwitch : ISwitch
    {
        public ElectricalSwitch(IEquipment equipment) : base(equipment)
        { 

        }
        public override void Off()
        {
            equipment.Stop();
        }

        public override void On()
        {
            equipment.Start();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ISwitch TVSwitch = new ElectricalSwitch(new TV());
            TVSwitch.On();
            TVSwitch.Off();

            ISwitch fanSwitch = new ElectricalSwitch(new Fan());
            fanSwitch.On();
            fanSwitch.Off();

            ISwitch radioSwitch = new ElectricalSwitch(new Radio());
            fanSwitch.On();

        }
    }
}
