using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    class ShoppingMall
    {
        public string CustomerName { get; set; }
        public int BillAmount { get; set; }


        public IStrategy CurrentStrategy;

        public ShoppingMall(IStrategy newStrategy)
        {
            CurrentStrategy = newStrategy;
        }

        public int GetFinalBill()
        {
            return CurrentStrategy.GetFinalBillAmount(this.BillAmount);
        }
    }
}
