using System;

namespace FactoryMethodDesignPatternStructure
{
    /// <summary>
    /// 1. Abstract Product
    /// </summary>
    abstract class Product
    { 
        
    }

    /// <summary>
    /// 2. Factory Method Class
    /// </summary>
    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

//-----------------------------------------------------------------------------------------

    /// <summary>
    /// Concrete Product A
    /// </summary>
    class ConcreteProductA : Product
    { 
    
    }

    /// <summary>
    /// Concrete Product B
    /// </summary>
    class ConcreteProductB : Product
    {

    }

    /// <summary>
    /// Concrete Creator A
    /// </summary>
    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    /// <summary>
    /// Concrete Creator B
    /// </summary>
    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }






    class Program
    {
        static void Main(string[] args)
        {
            //3. Initilize the Creator Array
            Creator[] creators = new Creator[2];

            //4. Create new Creator
            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();



            foreach (Creator creator in creators)
            {
                //5. Create Product
                Product product = creator.FactoryMethod();

                Console.WriteLine("Created {0}", product.GetType().Name);
            }
        }
    }
}
