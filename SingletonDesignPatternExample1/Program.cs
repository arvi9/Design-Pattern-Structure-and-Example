using System;

namespace SingletonDesignPatternExample1
{

    //Design Pattern: In Singleton pattern only one object is created for the class and that object is shared across all the clients,this approach is used when we want to make something centralized  
    public class Toyota
    {
        public string ManiFacturingPlantName = "india";


        //Step 1 : Declare a private constructor for the class for which you want to make Singleton.
        private Toyota()
        {


        }

        //Step 2 : Declare a static variable for that class.
        public static Toyota obj;

        //Step 3: Create a static method for that class and assign the object to the declared static variable.
        public static Toyota GetInstance()
        {

            if (obj == null)
            {
                obj = new Toyota();
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
            Toyota toyota2 = Toyota.GetInstance();

            toyota1.ManiFacturingPlantName = "Japan";
            string toyota2plantName = toyota2.getDetails();
            Console.WriteLine(toyota2plantName);

            //Compare if two instances are equal
            Console.WriteLine(toyota1.Equals(toyota2)); // True

            Console.ReadKey();
        }
    }
}
