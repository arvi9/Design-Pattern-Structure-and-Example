﻿using System;

namespace ChainOfResponsibilityDesignPattern
{
    /// <summary>
    /// Abstract Handler
    /// </summary>
    abstract class Handler
    {
        /// <summary>
        /// Protected Handler -- Stores the Next Request Object Reference.
        /// </summary>
        protected Handler successor;
        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(int request);
    }


    class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Console.WriteLine("{0} handle request {1}", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request); 
            }
        }
    }


    class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine("{0} handle request {1}", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    class ConcreteHandler3 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine("{0} handle request {1}", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //1. Handlers Object
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();

            //2. Set Successors
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            //3. Initilize Requests
            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

            //4. Send Request
            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }
        }
    }
}
