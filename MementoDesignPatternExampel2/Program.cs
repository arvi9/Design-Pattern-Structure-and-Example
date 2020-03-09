using System;

namespace MementoDesignPatternExampel2
{

    /// <summary>
    /// The Originator class, which is the class for which we want to save Mementos for its state.
    /// </summary>
    class FoodSupplier
    {
        private string _name;
        private string _phone;
        private string _address;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Console.WriteLine("Proprietor:  " + _name);
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                Console.WriteLine("Phone Number: " + _phone);
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                Console.WriteLine("Address: " + _address);
            }
        }

        public FoodSupplierMemento SaveMemento()
        {
            Console.WriteLine("\nSaving current state\n");
            return new FoodSupplierMemento(_name, _phone, _address);
        }

        public void RestoreMemento(FoodSupplierMemento memento)
        {
            Console.WriteLine("\nRestoring previous state\n");
            Name = memento.Name;
            Phone = memento.PhoneNumber;
            Address = memento.Address;
        }
    }

    /// <summary>
    /// The Memento class
    /// </summary>
    class FoodSupplierMemento
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public FoodSupplierMemento(string name, string phone, string address)
        {
            Name = name;
            PhoneNumber = phone;
            Address = address;
        }
    }


    /// <summary>
    /// The Caretaker class.  This class never examines the contents of any Memento and is
    /// responsible for keeping that memento.
    /// </summary>
    class SupplierMemory
    {
        private FoodSupplierMemento _memento;

        public FoodSupplierMemento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Here's a new supplier for our restaurant
            FoodSupplier s = new FoodSupplier();
            s.Name = "Harold Karstark";
            s.Phone = "(482) 555-1172";

            // Let's store that entry in our database.
            SupplierMemory m = new SupplierMemory();
            m.Memento = s.SaveMemento();

            // Continue changing originator
            s.Address = "548 S Main St. Nowhere, KS";

            // Crap, gotta undo that entry, I entered the wrong address
            s.RestoreMemento(m.Memento);

            Console.ReadKey();
        }
    }
}
