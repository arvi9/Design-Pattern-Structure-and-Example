using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    /// <summary>
    /// Abstract Observer
    /// </summary>
    abstract class ObserverAbstract
    {
        //Update the Subject to Observers
        public abstract void Update(string data1, string data2);
    }


    /// <summary>
    /// Subject is Abstract
    /// </summary>
    abstract class SubjectAbstract
    {
        public abstract void Susbscribe(ObserverAbstract observer);
        public abstract void UnSusbscribe(ObserverAbstract observer);
        public abstract void Notify();
    }

   

    /// <summary>
    /// Concrete Subject
    /// </summary>
    class SubjectConcrete : SubjectAbstract
    {
        //Data Passsed to Observers
        public string Data1 { get; set; }
        public string Data2 { get; set; }


        /// <summary>
        /// List of Observers
        /// </summary>
        private List<ObserverAbstract> _observers = new List<ObserverAbstract>();


        public override void Susbscribe(ObserverAbstract observer)
        {
            _observers.Add(observer);
        }

        public override void UnSusbscribe(ObserverAbstract observer)
        {
            _observers.Remove(observer);
        }
        public override void Notify()
        {
            foreach (ObserverAbstract o in _observers)
            {
                // data1, data2 is passed to Observer
                o.Update(this.Data1, this.Data2);
            }
        }
    }

    /// <summary>
    /// Concrete Observer
    /// </summary>
    class ObserverConcrete : ObserverAbstract
    {
        /// <summary>
        /// Observer Name
        /// </summary>
        private string _observerName;

        public ObserverConcrete(string observerName)
        {
            _observerName = observerName;

        }
        public override void Update(string data1, string data2)
        {
            Console.WriteLine($"Data Received by Observer Name: {_observerName} ---> Data1 = {data1} and Data2 = {data2}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new Subject
            SubjectConcrete subject = new SubjectConcrete();

            //Add Subscriberes
            subject.Susbscribe(new ObserverConcrete("Arvind"));
            subject.Susbscribe(new ObserverConcrete("Anand"));
            subject.Susbscribe(new ObserverConcrete("Mukund"));

            //Change the data
            subject.Data1 = "100";
            subject.Data2 = "200";

            //Push  data to Observers
            subject.Notify();
        }
    }
}
