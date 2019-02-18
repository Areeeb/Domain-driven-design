using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign
{
    interface Account
    {
        CardNumber cardNumber { get; set; }
        Pin pin { get; set; }
        Balance AccountBalance { get; set; }
        Account Login(CardNumber cardNumber, Pin pin);
        void ProcessCashTransaction(CashTransaction transation, Account userAccount);
        void ProcessNonCashTransaction(NonCashTransaction transaction, Account userAccount);
        Account makeAccount(CardNumber cardNumber, Pin pin);
    }
}
