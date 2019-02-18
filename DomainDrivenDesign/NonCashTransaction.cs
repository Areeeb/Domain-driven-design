using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign
{
    interface NonCashTransaction
    {
        void process(Account userAccount);
    }
}
