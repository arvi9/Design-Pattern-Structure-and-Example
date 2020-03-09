using System;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingMall shopping = new ShoppingMall(null);
            shopping.CustomerName = "Arvind D C";
            shopping.BillAmount = 1000;

            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    shopping.CurrentStrategy = new LowDiscount();
                    break;
                case DayOfWeek.Tuesday:
                    shopping.CurrentStrategy = new HighDiscount();
                    break;
                default: shopping.CurrentStrategy = new NoDiscountStrategy();
                    break;

            }

            Console.WriteLine("Dear {0}, Total Bill Amount after Discount is  {1}", shopping.CustomerName, shopping.GetFinalBill());

            Console.ReadKey();
        }
    }
}
