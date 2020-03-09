﻿using System;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup context in a state

            Context c = new Context(new ConcreteStateA());

            // Issue requests, which toggles state

            c.Request();
            c.Request();
            c.Request();
            c.Request();

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>

    /// The 'State' abstract class

    /// </summary>

    abstract class State

    {
        public abstract void Handle(Context context);
    }

    /// <summary>

    /// A 'ConcreteState' class

    /// </summary>

    class ConcreteStateA : State

    {
        public override void Handle(Context context)
        {
            //State Change from A --> A
            context.State = new ConcreteStateB();
        }
    }

    /// <summary>

    /// A 'ConcreteState' class

    /// </summary>

    class ConcreteStateB : State

    {
        public override void Handle(Context context)
        {
            //State Change from B --> A
            context.State = new ConcreteStateA();
        }
    }

    /// <summary>

    /// The 'Context' class

    /// </summary>

    class Context

    {
        private State _state;

        // Constructor
        public Context(State state)
        {
            this.State = state;
        }

        // Gets or sets the state
        public State State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("State: " + _state.GetType().Name);
            }
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }
}
