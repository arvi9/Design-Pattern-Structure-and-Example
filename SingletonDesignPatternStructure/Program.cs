using System;

namespace SingletonDesignPatternStructure
{

    /// <summary>
    /// 1. Sealed Class
    /// </summary>
    public sealed class Singleton
    {
        //2. Thread Safe SingleTon
        private static readonly Singleton instance = new Singleton();
       
        private int numberOfInstances = 0;

        
        /// <summary>
        /// 3.  Private constructor --> Is used to prevent creation of instances with 'new' keyword outside this class
        /// </summary>
        private Singleton()
        {
            Console.WriteLine("Instantiating inside the private constructor.");
            numberOfInstances++;
            Console.WriteLine("Number of instances ={0}", numberOfInstances);
        }
        public static Singleton Instance
        {
            get
            {
                Console.WriteLine("We already have an instance now.Use it.");
                return instance;
            }
        }
       
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Trying to create instance s1.");
            Singleton s1 = Singleton.Instance;
            Console.WriteLine("Trying to create instance s2.");
            Singleton s2 = Singleton.Instance;

            if (s1 == s2)
            {
                Console.WriteLine("Only one instance exists.");
            }
            else
            {
                Console.WriteLine("Difference instances exist.");
            }


        }
    }
}
