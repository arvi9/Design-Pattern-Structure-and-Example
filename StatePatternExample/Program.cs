using System;

namespace StatePatternExample
{
    /// <summary>
    /// Abstract State -- Abstaract Class
    /// </summary>
    public interface ITVStates
    {
        void PressOnButton(TV context);
        void PressOffButton(TV context);
        void PressMuteButton(TV context);
    }

    /// <summary>
    /// Concrete State 1 -> Off
    /// </summary>
    class Off : ITVStates
    {
         public Off(TV context)
        {
            Console.WriteLine("TV is off now");   
        }
        public void PressOnButton(TV context)
        {
            Console.WriteLine(" You pressed On button.Going from Off to On state");
            context.CurrentState = new On(context);
        }
        public void PressMuteButton(TV context)
        {
            Console.WriteLine(" You pressed Mute button.TV is already in Off state, so Mute operation will not work.");
        }

        public void PressOffButton(TV context)
        {
            Console.WriteLine(" You pressed Off button. TV is already in Off state");
        }

       
    }
    /// <summary>
    /// Concrete State 2 -> On
    /// </summary>
    public class On : ITVStates
    {
        public On(TV context)
        {
            Console.WriteLine(" TV is On now.");
        }
        public void PressMuteButton(TV context)
        {
            Console.WriteLine("You pressed Mute button.Going from On to Mute mode.");
            context.CurrentState = new Mute(context);
        }

        public void PressOffButton(TV context)
        {
            Console.WriteLine(" You pressed Off button.Going from On to Off state.");
            context.CurrentState = new Off(context);
        }

        public void PressOnButton(TV context)
        {
            Console.WriteLine("You pressed On button. TV is already in On state.");
        }
    }

    /// <summary>
    /// Concrete State 3 -> Mute
    /// </summary>
    public class Mute : ITVStates
    {
        public Mute(TV context)
        {
            Console.WriteLine(" TV is in Mute mode now.");
        }
        public void PressMuteButton(TV context)
        {
            Console.WriteLine(" You pressed Mute button.TV is already in Mute mode.");
        }

        public void PressOffButton(TV context)
        {
            Console.WriteLine("You pressed Off button. Going to Mute mode to Off state.");
            context.CurrentState = new Off(context);
        }

        public void PressOnButton(TV context)
        {
            Console.WriteLine("You pressed On button.Going from Mute mode to On state.");
            context.CurrentState = new On(context);
        }
    }


    /// <summary>
    /// Context Class --> TV (has a) StateChage Remote Interface
    /// </summary>
    public class TV
    {
        private ITVStates currentState;

        public ITVStates CurrentState
        {
            get { return currentState;  }
            set { currentState = value; }
        }

        public TV()
        {
            this.currentState = new Off(this); 
        }

        public void PressOffButton()
        {
            currentState.PressOffButton(this);//Deligate the state
        }

        public void PressOnButton()
        {
            currentState.PressOnButton(this);//Deligate the state
        }
        public void PressMuteButton()
        {
            currentState.PressMuteButton(this);//Deligate the state
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            // Setup context in a state
            TV tv = new TV();

            // Issue requests, which toggles state
            tv.PressOnButton();

            tv.PressMuteButton();

            tv.PressOffButton();
        }
    }
}
