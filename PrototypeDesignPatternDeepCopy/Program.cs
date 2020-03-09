using System;

namespace PrototypeDesignPatternDeepCopy
{

    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public Address EmpAddress { get; set; }

        /// <summary>
        /// Deep Cloning
        /// </summary>
        /// <returns>Deep Cloned Object</returns>
        public Employee GetClone()
        {
            Employee employee = (Employee)this.MemberwiseClone();
            employee.EmpAddress = EmpAddress.GetClone();
            return employee;
        }
    }

    public class Address
    {
        public string address { get; set; }
        public Address GetClone()
        {
            return (Address)this.MemberwiseClone();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Employee emp1 = new Employee();
            emp1.Name = "Anurag";
            emp1.Department = "IT";
            emp1.EmpAddress = new Address() { address = "BBSR" };

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
