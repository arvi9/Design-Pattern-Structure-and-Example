using System;

namespace AbstractFactoryDesignPatternExample1
{
    /// <summary>
    ///Abstract Product A  - fan
    /// </summary>
    interface IFan
    {
    }

    /// <summary>
    /// Abstract Product A  - fan
    /// </summary>
    interface ITubelight
    {
        
    }

    // <summary>
    /// Abstract Factrory for Manifacturing Fan and Tubelight
    /// </summary>
    interface AbstractFactory
    {
        IFan GetFan();
        ITubelight GetTubelight();
    }

    //----------------------------------------------------------------------------------------

    #region ProductGroupA
    class USAFan : IFan
    {

    }

    class IndianFan : IFan
    {

    }
    #endregion


    #region ProductGroupB
    class USATubeLight : ITubelight
    {

    }

    class IndianTubeLight : ITubelight
    {

    }
    #endregion


    /// <summary>
    /// USA Factory #1 Which maifactures ProductA1 and ProductB1
    /// </summary>
    class USAFactory : AbstractFactory
    {
        public IFan GetFan()
        {
           return new USAFan();
        }

        public ITubelight GetTubelight()
        {
            return new USATubeLight();
        }
    }


    /// <summary>
    /// Indian Factory #2 Which maifactures ProductA2 and ProductB2
    /// </summary>
    class IndianFactory: AbstractFactory
    {
        public IFan GetFan()
        {
           return new IndianFan();
        }

        public ITubelight GetTubelight()
        {
            return new IndianTubeLight();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Indian Factory --------------------------1 
            AbstractFactory indianFactory1 = new IndianFactory();

            //Indian Factory Products -  Fan, Tubelight
            IFan indianfan = indianFactory1.GetFan();
            ITubelight indianTubelight = indianFactory1.GetTubelight();



            //USA Factory --------------------------1
            AbstractFactory USAFactory1 = new USAFactory();

            //USA Factory Products -  Fan, Tubelight
            IFan USAfan = USAFactory1.GetFan();
            ITubelight USATubelight = USAFactory1.GetTubelight();


        }
    }
}
