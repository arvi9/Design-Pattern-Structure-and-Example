using System;

namespace AbstractFactoryDesignPatternStructure
{
    /// <summary>
    /// Abstract Product A
    /// </summary>
    abstract class AbstractProductA
    { 
        
    }

    /// <summary>
    /// Abstract Product B
    /// </summary>
    abstract class AbstractProductB
    {

    }

    /// <summary>
    /// Abstract Factrory 
    /// </summary>
    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    //----------------------------------------------------------------------------------------
    #region ProductGroupA
     
    class ProductA1 : AbstractProductA
    { 
        
    }

    class ProductA2:AbstractProductA
    {

    }
    #endregion

    #region ProductGroupB
    class ProductB1 : AbstractProductB
    { 
    
    }

    class ProductB2 : AbstractProductB
    {

    }
    #endregion


    /// <summary>
    /// Concrete Factory #1 Which maifactures ProductA1 and ProductB1
    /// </summary>
    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
           return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }


    /// <summary>
    /// Concrete Factory #2 Which maifactures ProductA2 and ProductB2
    /// </summary>
    class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }









    class Program
    {
        static void Main(string[] args)
        {
            //Abstract Factory #1
            AbstractFactory factory1 = new ConcreteFactory1();

            //Create Product of Factory1
            AbstractProductA abstractProductAFactory1 = factory1.CreateProductA();
            AbstractProductB abstractProductBFactory1 = factory1.CreateProductB();


            //Abstract Factory #2
            AbstractFactory factory2 = new ConcreteFactory2();

            //Create Product of Factory2
            AbstractProductA abstractProductAFactory2 = factory2.CreateProductA();
            AbstractProductB abstractProductBFactory2 = factory2.CreateProductB();



            Console.ReadKey();
        }
    }
}
