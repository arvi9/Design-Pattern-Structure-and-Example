using System;

namespace ProxyDesignPatternStructure
{
    /// <summary>
    /// Abstract  Subject
    /// </summary>
    public abstract class Subject
    {
        public abstract void DoSomeWork();
    }
    /// <summary>
    /// ConcreteSubject class
    /// </summary>
    public class ConcreteSubject : Subject
    {
        public override void DoSomeWork()
        {
            Console.WriteLine("ConcreteSubject.DoSomeWork()");
        }
    }
    /// <summary>
    /// Proxy class
    /// </summary>
    public class Proxy : Subject
    {
        Subject cs; // Reference of the Subject

        public override void DoSomeWork()
        {
            Console.WriteLine("Proxy call happening now...");
            //Lazy initialization:We'll not instantiate until the method is called
            if (cs == null)
            {
                cs = new ConcreteSubject(); // Subject Object Creation
            }
            cs.DoSomeWork();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           
            Proxy px = new Proxy();
            px.DoSomeWork();


            Console.ReadKey();
        }
    }
}
