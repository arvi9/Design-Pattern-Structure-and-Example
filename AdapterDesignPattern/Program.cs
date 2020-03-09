using System;

namespace AdapterDesignPattern
{
    /// <summary>
    /// XML File
    /// </summary>
    public class XML
    {

    }

    /// <summary>
    /// JSON File
    /// </summary>
    public class JSON
    {

    }


    /// <summary>
    /// Target Adapter Interface - Contains abstract method to convert XML to JSON
    /// </summary>
    public abstract class ITarget
    {
        public abstract void XMLtoJSONConverter(XML xml);

    }

    /// <summary>
    /// Adapter --> XML to JSON Converter
    /// </summary>
    class Adapter : ITarget
    {
        private Adaptee adaptee = new Adaptee();

        public override void XMLtoJSONConverter(XML xml)
        {
            Console.WriteLine("Received {0} file", xml.GetType().Name);
            //Logic to Convert XML to JSON
            Console.WriteLine("Please wait. Converting XML to JSON ...........");

            adaptee.SpecificRequest(new JSON());
        }
    }

    /// <summary>
    /// Adaptee - Is third party program which wants JSON as Input, But we have XML. So we are converting XML to JSON using Adapter.
    /// </summary>
    class Adaptee
    {
        /// <summary>
        /// Accepts only JSON
        /// </summary>
        /// <param name="json">JSON</param>
        public void SpecificRequest(JSON json)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("I Accept only Json");
            Console.WriteLine("Received {0} file, Thank you.", json.GetType().Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //1. We have XML File. 2. We need to send it to Adaptee(Third Party), But he only accepts JSON 3. So, We use Adapter to Convert XML to JSON  and Send JSON to Adaptee

            ITarget target = new Adapter();
            //Send XML File
            target.XMLtoJSONConverter(new XML());


            Console.ReadKey();
        }
    }
}
