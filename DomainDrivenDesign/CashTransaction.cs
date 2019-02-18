using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign
{
    interface CashTransaction
    {
        Money amount { get; set; }
        void process(Account userAccount, Money money);
    }
}
