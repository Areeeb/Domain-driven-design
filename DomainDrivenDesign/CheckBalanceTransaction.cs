using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign
{
    class CheckBalanceTransaction: NonCashTransaction
    {

        public void process(Account userAccount)
        {
            Console.WriteLine("\nBalance is " + userAccount.AccountBalance.BalanceAmount.amount);
        }
    }
}
