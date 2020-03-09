using System;
using System.Collections.Generic;

namespace VisitorDesignPatternStructure
{
    /// <summary>
    /// Visitor
    /// </summary>
    public interface IVisitor
    {
        public void Visit(Element element);
    }

    /// <summary>
    /// Element - Data Structure Element
    /// </summary>
    public abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }

    public class Customer : Element
    {
        private string name;
        private string address;
        private string phoneNumber;

        public Customer(string name, string address, string phoneNumber)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Customers
    {
        List<Customer> customers = new List<Customer>();

        public void Attach(Customer customer)
        {
            customers.Add(customer);
        }

        public void Detach(Customer customer)
        {
            customers.Remove(customer);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Customer customer in customers)
            {
                customer.Accept(visitor);
            }
        }
    }

    /// <summary>
    /// String Visitor
    /// </summary>
    public class PrintOutputInString : IVisitor
    {
        public void Visit(Element element)
        {
            Customer customer = element as Customer;

            Console.WriteLine("Name: {0}", customer.Name);
            Console.WriteLine("Address: {0}", customer.Address);
            Console.WriteLine("Phone: {0}", customer.PhoneNumber);
        }
    }

    /// <summary>
    /// XML Visitor
    /// </summary>
    public class PrintOutputInXML : IVisitor
    {
        public void Visit(Element element)
        {
            Customer customer = element as Customer;

            Console.WriteLine("<name> {0} </customername>", customer.Name);
            Console.WriteLine("<address> {0} </address>", customer.Address);
            Console.WriteLine("<phone> {0} </phone>", customer.PhoneNumber);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer("Arvind", "Banglore", "8989898989");
            Customer customer2 = new Customer("Anand", "Turuvekere", "9999999999");
            Customer customer3 = new Customer("Karthik", "USA", "1000001");

            Customers customers = new Customers();
            customers.Attach(customer1);
            customers.Attach(customer2);
            customers.Attach(customer3);

            Console.WriteLine("---------------STRING----------------------");
            //Customers visit -- string
            customers.Accept(new PrintOutputInString());

            Console.WriteLine("---------------XML----------------------");
            //Customers visit -- XML
            customers.Accept(new PrintOutputInXML());

            Console.ReadKey();
        }
    }
}
