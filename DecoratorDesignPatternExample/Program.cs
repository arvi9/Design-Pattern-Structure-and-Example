using System;

namespace DecoratorDesignPatternExample
{
    /// <summary>
    /// Abstract Component - Pizza
    /// </summary>
    public interface Pizza
    {
        string MakePizza();
    }

    /// <summary>
    /// Abstract Decorator
    /// </summary>
    public abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;

        public PizzaDecorator(Pizza pizza)
        {
            this.pizza = pizza;
        }

        public virtual string MakePizza()
        {
            return pizza.MakePizza();
        }
    }
//--------------------------------------------------------------------------------------

    /// <summary>
    /// Concrete  Component
    /// </summary>
    public class PlainPizza : Pizza
    {
        public string MakePizza()
        {
            return "Plain Pizza";
        }
    }

    /// <summary>
    /// Concrete Decorator A
    /// </summary>
    public class ChickenPizzaDecorator : PizzaDecorator
    {
        public ChickenPizzaDecorator(Pizza pizza) : base(pizza)
        {
        }

        public override string MakePizza()
        {
            return pizza.MakePizza() + AddChicken();
        }

        private string AddChicken()
        {
            return ", Chicken added";
        }
    }

    /// <summary>
    /// Concrete Decorator B
    /// </summary>
    public class VegPizzaDecorator : PizzaDecorator
    {
        public VegPizzaDecorator(Pizza pizza) : base(pizza)
        {
        }

        public override string MakePizza()
        {
            return pizza.MakePizza() + AddVegetables();
        }

        private string AddVegetables()
        {
            return ", Vegetables added";
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            PlainPizza plainPizzaObj = new PlainPizza();
            string plainPizza = plainPizzaObj.MakePizza();
            Console.WriteLine(plainPizza);

            //Add Decoration to Plain Pizza Object
            PizzaDecorator chickenPizzaDecorator = new ChickenPizzaDecorator(plainPizzaObj);
            string chickenPizza = chickenPizzaDecorator.MakePizza();
            Console.WriteLine("\n'" + chickenPizza + "' using ChickenPizzaDecorator");

            //Add Decoration to Plain Pizza Object
            VegPizzaDecorator vegPizzaDecorator = new VegPizzaDecorator(plainPizzaObj);
            string vegPizza = vegPizzaDecorator.MakePizza();
            Console.WriteLine("\n'" + vegPizza + "' using VegPizzaDecorator");

            Console.Read();

        }
    }
}
