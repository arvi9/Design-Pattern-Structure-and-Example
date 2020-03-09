using System;
using System.Collections.Generic;

namespace BuilderDesignPatternStructure
{
    /// <summary>
    /// The 'Product' class
    /// </summary>
    class Product
    {
        List<string> parts = new List<string>();
        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("\nProduct Parts -------");
            foreach (string part in parts)
                Console.WriteLine(part);
        }
    }

    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        //Get Product
        public abstract Product GetResult();
    }


    /// <summary>
    /// The 'Director' class
    /// </summary>
    class Director
    {
        // Builder uses a complex series of steps
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }

    //--------------------------------------------------------------------------------------

    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    class ConcreteBuilder1 : Builder
    {
        Product product = new Product();

        public override void BuildPartA()
        {
            product.Add("PartA");
        }

        public override void BuildPartB()
        {
            product.Add("PartB");
        }

        public override Product GetResult()
        {
            return product;
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    class ConcreteBuilder2 : Builder
    {
        Product product = new Product();

        public override void BuildPartA()
        {
            product.Add("PartX");
        }

        public override void BuildPartB()
        {
            product.Add("PartY");
        }

        public override Product GetResult()
        {
            return product;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Director
            Director director = new Director();

            //2. Builder
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            //3. Construct Product 1
            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();

            //4. Construct Product 2
            Product p2 = b2.GetResult();
            p2.Show();
        }
    }
}
