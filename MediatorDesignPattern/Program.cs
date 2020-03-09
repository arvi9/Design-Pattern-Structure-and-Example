using System;
using System.Collections.Generic;

namespace MediatorDesignPattern
{
    /// <summary>
    /// 1. Mediator - Center communication center for all objects.
    /// </summary>
    public abstract class Mediator
    {
        public abstract void RegisterUser(User user);
        public abstract void SendMessage(string message, User user);
    }

    /// <summary>
    /// 2. User (Has a) reference of Mediator
    /// </summary>
    public abstract class User
    {
        protected Mediator mediator;
        protected string userName;

        public User(Mediator mediator, string userName)
        {
            this.mediator = mediator;
            this.userName = userName;
        }

        public abstract void Send(string message);
        public abstract void Receive(string message);

    }

    /// <summary>
    /// 3. Concrete Mediator
    /// </summary>
    class ConcreteMediator : Mediator
    {
        private List<User> userList = new List<User>();

        public override void RegisterUser(User user)
        {
            userList.Add(user);
        }


        public override void SendMessage(string message, User user)
        {
            foreach (var u in userList)
            {
                // message should not be received by the user sending it
                if (u != user)
                {
                    u.Receive(message);
                }

            }
        }
    }

    /// <summary>
    /// 3. Concrete User
    /// </summary>
    public class ConcreteUser : User
    {
        public ConcreteUser(Mediator mediator, string userName) : base(mediator, userName)
        { 
        }
        public override void Receive(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(this.userName + ": Received Message:" + message);
        }

        public override void Send(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(this.userName + ": Sending Message= " + message + "\n");
            mediator.SendMessage(message, this);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //1. Create a Mediator
            Mediator mediator = new ConcreteMediator();

            //2. Create Users
            User Ram = new ConcreteUser(mediator, "Ram");
            User Dave = new ConcreteUser(mediator, "Dave");
            User Smith = new ConcreteUser(mediator, "Smith");
            User Rajesh = new ConcreteUser(mediator, "Rajesh");
            User Sam = new ConcreteUser(mediator, "Sam");
            User Pam = new ConcreteUser(mediator, "Pam");
            User Anurag = new ConcreteUser(mediator, "Anurag");
            User John = new ConcreteUser(mediator, "John");

            //3. Register Users
            mediator.RegisterUser(Ram);
            mediator.RegisterUser(Dave);
            mediator.RegisterUser(Smith);
            mediator.RegisterUser(Rajesh);
            mediator.RegisterUser(Sam);
            mediator.RegisterUser(Pam);
            mediator.RegisterUser(Anurag);
            mediator.RegisterUser(John);

            //4. Send Message from --> Ram to All Registered Users
            Ram.Send("Hi this is Ram, How are you All");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-------------------------End of Message-------------------------------");
            
            
        }
    }
}
