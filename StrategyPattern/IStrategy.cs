using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    /// <summary>
    /// Stratagy Interface used for applying different discounts on Bill Amount 
    /// </summary>
    interface IStrategy
    {
        int GetFinalBillAmount(int BillAmount);
    }
}
