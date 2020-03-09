using System;

namespace PrototypeDesignPatternShallowCopy
{
    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public Address EmpAddress { get; set; }

        /// <summary>
        /// Shallow Cloning
        /// </summary>
        /// <returns>Shallow Object</returns>
        public Employee GetClone()
        {
            return (Employee)this.MemberwiseClone();
        }
    }

    public class Address
    {
        public string address { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee();
            emp1.Name = "Anurag";
            emp1.Department = "IT";
            emp1.EmpAddress = new Address() { address = "BBSR" };

            //Shallow Cloning
            Employee emp2 = emp1.GetClone();

            emp2.Name = "Pranaya";
            emp2.EmpAddress.address = "Mumbai";

            Console.WriteLine("Emplpyee 1: ");
            Console.WriteLine("Name: " + emp1.Name + ", Address: " + emp1.EmpAddress.address + ", Dept: " + emp1.Department);
            Console.WriteLine("Emplpyee 2: ");
            Console.WriteLine("Name: " + emp2.Name + ", Address: " + emp2.EmpAddress.address + ", Dept: " + emp2.Department);

            Console.Read();

        }
    }
}
