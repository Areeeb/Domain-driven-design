using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign
{
    class WithdrawCashTransaction: CashTransaction
    {
        public Money amount { get; set; }
        public void process(Account userAccount, Money money)
        {
            this.amount = money;
            userAccount.AccountBalance.BalanceAmount.amount -= this.amount.amount;
            Console.WriteLine("Cash withdrawn");
        }
    }
}
