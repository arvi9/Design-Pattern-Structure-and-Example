using System;

namespace SingletonDesignPatternThreadSafe
{

    //Design Pattern: In Singleton pattern only one object is created for the class and that object is shared across all the clients,this approach is used when we want to make something centralized  
    public class Toyota
    {
        public string ManiFacturingPlantName = "india";
        // syncLock object, used to lock the code block --> Making Thread Safe

        // Note:(SingletonCarExampleNonThreadSafe) As we have seen before, the above is not thread-safe. Two different threads could both have evaluated the test if (obj==null) and found it to be true, and create both the instances, which violate the Singleton pattern
        private static readonly object syncLock = new object();

        //Step 1 : Declare a private constructor for the class for which you want to make Singleton.
        private Toyota()
        {


        }

        //Step 2 : Declare a static variable for that class.
        public static Toyota obj;

        //Step 3: Create a static method for that class and assign the object to the declared static variable.
        public static Toyota GetInstance()
        {
            lock (syncLock)
            {
                if (obj == null)
                {
                    obj = new Toyota();
                }
            }

            return obj;
        }

        public string getDetails()
        {
            return ManiFacturingPlantName;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Toyota toyota1 = Toyota.GetInstance();
            toyota1.ManiFacturingPlantName = "Japan";
            Toyota toyota2 = Toyota.GetInstance();


            string toyota2plantName = toyota2.getDetails();
            Console.WriteLine(toyota2plantName);
            Console.WriteLine(toyota1.Equals(toyota2));

            Console.ReadKey();
        }
    }
}
