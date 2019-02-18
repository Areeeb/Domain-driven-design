using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign
{
    class TransferCashTransaction: CashTransaction
    {
        public Money amount { get; set; }
        public CardNumber RecieverBankAccount { get; set; }
        public Money ServiceFee { get; set; }
        AccountRepository accountRepository = new AccountRepository();

        public void process(Account userAccount, Money money)
        {
            this.amount.amount = money.amount;
            
            Console.WriteLine("\nEnter the reciever ATM account number");
            this.RecieverBankAccount.cardNumber = Console.ReadLine();
            IReadOnlyCollection<Account> ATMaccounts = accountRepository.ATMaccounts;
            foreach(Account ATMaccount in ATMaccounts)
            {
                if (ATMaccount.cardNumber.cardNumber.Equals(this.RecieverBankAccount.cardNumber))
                {
                    ServiceFee = new Dollar()
                    {
                        amount = 10
                    };
                    Console.WriteLine("\nService fee is " + ServiceFee.amount);
                    Console.WriteLine("\nAre you sure?");
                    ConsoleKey response = Console.ReadKey().Key;
                    if (response == ConsoleKey.Y)
                    {
                        userAccount.AccountBalance.BalanceAmount.amount -= this.amount.amount;
                        ATMaccount.AccountBalance.BalanceAmount.amount += this.amount.amount;
                        Console.WriteLine("\nCash Transfered");
                    }
                    else
                    {
                        Console.WriteLine("\nTransaction cancelled");
                    }
                    return;
                    
                }
            }
            Console.WriteLine("Account not found");
        }
    }
}
