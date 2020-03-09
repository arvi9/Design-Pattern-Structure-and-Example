using System;
using System.Collections.Generic;

namespace BuilderDesignPatternExample
{

    /// <summary>
    /// The 'Product' class
    /// </summary>
    class Vehicle
    {
        VehicleType vehicleType;
        Dictionary<PartType, string> parts = new Dictionary<PartType, string>();

        // Constructor
        public Vehicle(VehicleType vehicleType)
        {
            this.vehicleType = vehicleType;
        }

        public string this[PartType key]
        {
            get { return parts[key]; }
            set { parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Vehicle Type: {0}", vehicleType);
            Console.WriteLine(" Frame  : {0}",
                this[PartType.Frame]);
            Console.WriteLine(" Engine : {0}",
                this[PartType.Engine]);
            Console.WriteLine(" #Wheels: {0}",
                this[PartType.Wheel]);
            Console.WriteLine(" #Doors : {0}",
                this[PartType.Door]);
        }
    }

    /// <summary>
    /// Part type enumeration
    /// </summary>
    public enum PartType
    {
        Frame,
        Engine,
        Wheel,
        Door
    }

    /// <summary>
    /// Vehicle type enumeration
    /// </summary>
    public enum VehicleType
    {
        Car,
        Scooter,
        MotorCycle
    }

    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    abstract class VehicleBuilder
    {
        public Vehicle Vehicle { get; private set; }

        // Constructor
        public VehicleBuilder(VehicleType vehicleType)
        {
            Vehicle = new Vehicle(vehicleType);
        }

        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }

    /// <summary>
    /// The 'Director' class
    /// </summary>
    class Shop
    {
        VehicleBuilder vehicleBuilder;

        // Builder uses a complex series of steps
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            this.vehicleBuilder = vehicleBuilder;

            this.vehicleBuilder.BuildFrame();
            this.vehicleBuilder.BuildEngine();
            this.vehicleBuilder.BuildWheels();
            this.vehicleBuilder.BuildDoors();
        }

        public void ShowVehicle()
        {
            vehicleBuilder.Vehicle.Show();
        }
    }

    //-----------------------------------------------------------------------------
    /// <summary>
    ///  'ConcreteBuilder1' - Motor Cycle
    /// </summary>
    class MotorCycleBuilder : VehicleBuilder
    {
        // Invoke base class constructor
        public MotorCycleBuilder()
            : base(VehicleType.MotorCycle)
        {
        }

        public override void BuildFrame()
        {
            Vehicle[PartType.Frame] = "MotorCycle Frame";
        }

        public override void BuildEngine()
        {
            Vehicle[PartType.Engine] = "500 cc";
        }

        public override void BuildWheels()
        {
            Vehicle[PartType.Wheel] = "2";
        }

        public override void BuildDoors()
        {
            Vehicle[PartType.Door] = "0";
        }
    }

    /// <summary>
    /// ConcreteBuilder2 - Car Builder
    /// </summary>
    class CarBuilder : VehicleBuilder
    {
        // Invoke base class constructor
        public CarBuilder()
            : base(VehicleType.Car)
        {
        }

        public override void BuildFrame()
        {
            Vehicle[PartType.Frame] = "Car Frame";
        }

        public override void BuildEngine()
        {
            Vehicle[PartType.Engine] = "2500 cc";
        }

        public override void BuildWheels()
        {
            Vehicle[PartType.Wheel] = "4";
        }

        public override void BuildDoors()
        {
            Vehicle[PartType.Door] = "4";
        }
    }

    /// <summary>
    /// ConcreteBuilder3 - Scooter
    /// </summary>
    class ScooterBuilder : VehicleBuilder
    {
        // Invoke base class constructor
        public ScooterBuilder() : base(VehicleType.Scooter)
        {
        }

        public override void BuildFrame()
        {
            Vehicle[PartType.Frame] = "Scooter Frame";
        }

        public override void BuildEngine()
        {
            Vehicle[PartType.Engine] = "50 cc";
        }

        public override void BuildWheels()
        {
            Vehicle[PartType.Wheel] = "2";
        }

        public override void BuildDoors()
        {
            Vehicle[PartType.Door] = "0";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //1. Director
            var director = new Shop();

            //2. Scooter Builder
            director.Construct(new ScooterBuilder());
            director.ShowVehicle();

            //Car Builder
            director.Construct(new CarBuilder());
            director.ShowVehicle();

            //MotorCycle Builder
            director.Construct(new MotorCycleBuilder());
            director.ShowVehicle();

            Console.ReadKey();

        }
    }
}
