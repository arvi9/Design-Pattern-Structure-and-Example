using System;
using System.Collections.Generic;

namespace FactoryMethodExample1
{
    //1. Product Interface - Customer
    interface ICustomer
    {
        string CustomerName { get; set; }
        int Amount { set; get; }
        int GetTotalAmount();
    }


    //2. Factory - Customer Factory
    interface ICustomerFactory
    {
        ICustomer GetCustomerTypeFactoryMethod();
    }

    //-----------------------------------------------------------------------------------------


    //Grade1 - > A Tax of 12% will be applied to the total amount
    class Grade1Customer : ICustomer
    {
        public string CustomerName { get; set; }
        public int Amount { get; set; }

        public int GetTotalAmount()
        {
            return (int)(Amount - Amount * 0.12);
        }
    }

    // Grade2 - > A Tax of 30% will be applied to the total amount
    class Grade2Customer : ICustomer
    {
        public string CustomerName { get; set; }
        public int Amount { get; set; }

        public int GetTotalAmount()
        {
            return (int)(Amount - Amount * 0.3);
        }

    }

    //Grade3 - > A Tax of 40% will be applied to the total amount

    class Grade3Customer : ICustomer
    {
        public string CustomerName { get; set; }
        public int Amount { get; set; }

        public int GetTotalAmount()
        {
            return (int)(Amount - Amount * 0.4);
        }

    }

    //Creation of Object by Factory Method
    class CustomerFactoryGrade1 : ICustomerFactory
    {
        public ICustomer GetCustomerTypeFactoryMethod()
        {
            return new Grade1Customer();
        }
    }


    //Creation of Object by Factory Method
    class CustomerFactoryGrade2 : ICustomerFactory
    {
        public ICustomer GetCustomerTypeFactoryMethod()
        {
            return new Grade2Customer();
        }
    }

    //Creation of Object by Factory Method
    class CustomerFactoryGrade3 : ICustomerFactory
    {
        public ICustomer GetCustomerTypeFactoryMethod()
        {
            return new Grade3Customer();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //1. Factory Initilization
            List<ICustomerFactory> customerFactories = new List<ICustomerFactory>();


            customerFactories.Add(new CustomerFactoryGrade1());
            customerFactories.Add(new CustomerFactoryGrade2());
            customerFactories.Add(new CustomerFactoryGrade3());



            Console.WriteLine("Enter the Customer Grade ");
            int grade = int.Parse(Console.ReadLine());

            //2. Product Creation using Factory Method
            ICustomer customer = customerFactories[grade].GetCustomerTypeFactoryMethod();

            Console.WriteLine("Enter Customer Details ");
            string[] getInputData = InputValues();

            customer.CustomerName = getInputData[0];
            customer.Amount = int.Parse(getInputData[1]);

            Console.WriteLine("Total Amount after Tax for Grade{0} Customer = {1}", grade, customer.GetTotalAmount());




            Console.ReadKey();
        }

        //Take Input from Keyboard
        static string[] InputValues()
        {
            Console.Write("Input Customer Name , Amount --> ");
            String[] inputData = Console.ReadLine().Split(' ');
            return inputData;
        }
    }
}
