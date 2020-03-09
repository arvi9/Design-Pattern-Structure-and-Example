using System;

namespace TemplateMethodStructure
{
    /// <summary>
    /// Abstract -- Template Class
    /// </summary>
    abstract class TemplateAbstractClass
    {
        /// <summary>
        /// Protected Series of methods or Operations
        /// </summary>
        protected abstract void Step1();
        protected abstract void Step2();
        protected abstract void Step3();
        protected abstract void Step4();


        /// <summary>
        /// Template method has Series of steps, Whose sequence is not changable.
        /// </summary>
        public void TemplateMethod()
        {
            Step1();
            Step2();
            Step3();
            Step4();
        }

    }

    class ConcreteClassA : TemplateAbstractClass
    {
        protected override void Step1()
        {
            Console.WriteLine(" Step1 ");
        }

        protected override void Step2()
        {
            Console.WriteLine(" Step2 ");
        }

        protected override void Step3()
        {
            Console.WriteLine(" Step3 ");
        }

        protected override void Step4()
        {
            Console.WriteLine(" Step4 ");
        }
    }

    class ConcreteClassB : TemplateAbstractClass
    {
        protected override void Step1()
        {
            Console.WriteLine(" Step1 ");
        }

        protected override void Step2()
        {
            Console.WriteLine(" Step2 ");
        }

        protected override void Step3()
        {
            Console.WriteLine(" Step3 ");
        }

        protected override void Step4()
        {
            Console.WriteLine(" Step4 ");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            TemplateAbstractClass template = new ConcreteClassA();

            template.TemplateMethod();
        }
    }
}
