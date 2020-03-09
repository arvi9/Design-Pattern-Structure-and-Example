using System;

namespace DecoratorDesignPatternStructure
{
    /// <summary>
    /// 1. Component  - House
    /// </summary>
    abstract class Component
    {
        public abstract void MakeHouse();

    }

    /// <summary>
    /// 2. Abstract Decorator
    /// </summary>
    abstract class AbstractDecorator : Component
    {
        protected Component com;
        public void SetTheComponent(Component c)
        {
            com = c;
        }
        public override void MakeHouse()
        {
            if (com != null)
            {
                com.MakeHouse();//Delegating the task
            }
        }

    }

    /// <summary>
    /// 3. Concrete Component -- Original House Object
    /// </summary>
    class ConcreteComponent : Component
    {
        public override void MakeHouse()
        {
            Console.WriteLine("Original House Structure is complete. It is closed for modification.Open for Extention");
        }
    }


    class ConcreteDecoratorEx1 : AbstractDecorator
    {
        public override void MakeHouse()
        {
            base.MakeHouse();
            
            //Decorating now.
            AddFloor();
            //You can put additional stuffs as per your need
        }
        private void AddFloor()
        {
            Console.WriteLine("I am making an additional floor on top of it.");
        }
    }
    class ConcreteDecoratorEx2 : AbstractDecorator
    {
        public override void MakeHouse()
        {
            
            base.MakeHouse();
           
            //Decorating now.          
            PaintTheHouse();
            //You can put additional stuffs as per your need
        }
        private void PaintTheHouse()
        {
            Console.WriteLine("Now I am painting the house.");
        }
    }

    class ConcreteDecoratorEx3 : AbstractDecorator
    {
        public override void MakeHouse()
        {

            base.MakeHouse();

            //Decorating now.          
            AddTankOnTopFloor();
            //You can put additional stuffs as per your need
        }
        private void AddTankOnTopFloor()
        {
            Console.WriteLine("Add Tank on Top Floor");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //House
            ConcreteComponent cc = new ConcreteComponent();

            //Decorator 1
            AbstractDecorator decorator1 = new ConcreteDecoratorEx1();
            decorator1.SetTheComponent(cc);
            decorator1.MakeHouse();

            //Decorator 2
            AbstractDecorator decorator2 = new ConcreteDecoratorEx2();
            //Adding results from decorator1
            decorator2.SetTheComponent(decorator1);
            decorator2.MakeHouse();
        }
    }
}
