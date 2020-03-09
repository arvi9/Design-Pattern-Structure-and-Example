using System;

namespace StratagyDesignPatternStructure
{
    /// <summary>
    /// Stratagy Interface
    /// </summary>
    interface IStrategy
    {
        void AlgorithmInterface();
    }

    /// <summary>
    /// Context Class - Accepts Strategy and Calls Algorithmic Interface
    /// </summary>
    class Context
    {
        IStrategy strategy;

        // Constructor
        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ContextInterface()
        {
            strategy.AlgorithmInterface();
        }
    }
//-----------------------------------------------------------------------------------------

    /// <summary>
    ///Stratagy A
    /// </summary>
    class StrategyA : IStrategy
    {
        public  void AlgorithmInterface()
        {
            Console.WriteLine( "Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }

    /// <summary>
    /// Stratagy B
    /// </summary>
    class StrategyB : IStrategy
    {
        public void AlgorithmInterface()
        {
            Console.WriteLine( "Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }

    /// <summary>
    /// Stratagy C
    /// </summary>
    class StrategyC : IStrategy
    {
        public  void AlgorithmInterface()
        {
            Console.WriteLine("Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            Context context;

            
            context = new Context(new StrategyA());
            context.ContextInterface();

            context = new Context(new StrategyB());
            context.ContextInterface();

            context = new Context(new StrategyC());
            context.ContextInterface();
        }
    }
}
