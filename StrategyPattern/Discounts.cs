using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    public class NoDiscountStrategy : IStrategy
    {
        public int GetFinalBillAmount(int BillAmount)
        {
            return BillAmount;
            
        }
    }

    /// <summary>
    /// 10% Discount
    /// </summary>
    public class LowDiscount : IStrategy
    {
        public int GetFinalBillAmount(int BillAmount)
        {
            return (BillAmount - BillAmount * (10/100));
        }
    }

    /// <summary>
    /// 50% Discount
    /// </summary>
    public class HighDiscount : IStrategy
    {
        public int GetFinalBillAmount(int BillAmount)
        {
            return (BillAmount - BillAmount * (50 / 100)); ;
        }

        
    }
}
