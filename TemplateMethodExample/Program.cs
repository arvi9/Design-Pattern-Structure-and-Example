using System;

namespace TemplateMethodExample
{
    public abstract class CoffeeTemplate
    {
        protected abstract void BoilWater();
        protected abstract void AddMilk();
        protected abstract void AddSugar();
        protected abstract void AddCoffeePowder();

        // PrepareCoffee method is the template method
        public void TemplateMethodForPreparingCoffee()//Template Method
        {
            BoilWater();
            AddMilk();
            AddSugar();
            AddCoffeePowder();
            Console.WriteLine(this.GetType().Name + " is Ready");
        }
    }

    public class BruCoffee : CoffeeTemplate
    {
        protected override void BoilWater()
        {
            Console.WriteLine("Water Boild");
        }

        protected override void AddMilk()
        {
            Console.WriteLine("Milk Added");
        }

        protected override void AddSugar()
        {
            Console.WriteLine("Sugar Added");
        }
        protected override void AddCoffeePowder()
        {
            Console.WriteLine("Bru Coffee Powder Added");
        }
    }

    public class NescafeCoffee : CoffeeTemplate
    {
        protected override void BoilWater()
        {
            Console.WriteLine("Water Boild");
        }

        protected override void AddMilk()
        {
            Console.WriteLine("Milk Added");
        }

        protected override void AddSugar()
        {
            Console.WriteLine("Sugar Added");
        }
        protected override void AddCoffeePowder()
        {
            Console.WriteLine("Nescafe Coffee Powder Added");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            //Nescafe Coffee
            CoffeeTemplate coffee = new NescafeCoffee();
            coffee.TemplateMethodForPreparingCoffee();

            //Brue Coffee
            coffee = new BruCoffee();
            coffee.TemplateMethodForPreparingCoffee();


        }
    }
}
