using System;

namespace MementoDesignPattern
{

    /// <summary>
    /// The 'Originator' class
    /// creates a memento containing a snapshot of its current internal state.
   /// uses the memento to restore its internal state
    /// </summary>

    class Originator

    {
        private string _state;

        // Property
        public string State
        {
            get { return _state; }
            set

            {
                _state = value;
                Console.WriteLine("State = " + _state);
            }
        }

        // Creates memento 
        public Memento CreateMemento()
        {
            return (new Memento(_state));
        }

        // Restores original state
        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring state...");
            State = memento.State;
        }
    }

    /// <summary>
    /// The 'Memento' class
    /// stores internal state of the Originator object. The memento may store as much or as little of the originator's internal state as necessary at its originator's discretion.
    /// </summary>
    class Memento

    {
        private string _state;

        // Constructor

        public Memento(string state)
        {
            this._state = state;
        }

        // Gets or sets state

        public string State
        {
            get { return _state; }
        }
    }

    /// <summary>
    /// The 'Caretaker' class
    /// is responsible for the memento's safekeeping
   /// never operates on or examines the contents of a memento.
    /// </summary>
    class Caretaker

    {
        private Memento _memento;
        // Gets or sets memento
        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Originator o = new Originator();
            o.State = "On";

            // Store internal state

            Caretaker c = new Caretaker();
            c.Memento = o.CreateMemento();

            // Continue changing originator

            o.State = "Off";

            // Restore saved state

            o.SetMemento(c.Memento);

            // Wait for user

            Console.ReadKey();
        }
    }
}
