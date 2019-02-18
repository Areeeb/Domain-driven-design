using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign
{
    class TransactionalAccount: Account
    {
        public CardNumber cardNumber { get ; set; }
        public Pin pin { get; set; }
        public Balance AccountBalance { get; set; }
        public AccountRepository accountRepository = new AccountRepository();
        
        public Account Login(CardNumber cardNumber, Pin pin)
        {
            IReadOnlyCollection<Account> ATMaccounts = accountRepository.ATMaccounts;
            foreach(Account ATMaccount in ATMaccounts)
            {
                if (ATMaccount.cardNumber.cardNumber.Equals(cardNumber.cardNumber) && ATMaccount.pin.pin == pin.pin)
                {
                    return ATMaccount;
                }
            }
            return null;
        }

        public void ProcessCashTransaction(CashTransaction transaction, Account userAccount)
        {
            transaction.process(userAccount, transaction.amount);
        }
        public void ProcessNonCashTransaction(NonCashTransaction transaction, Account userAccount)
        {
            transaction.process(userAccount);
        }
        public Account makeAccount(CardNumber cardNumber, Pin pin)
        {
            Money money = new Dollar()
            {
                amount = 0,
                ServiceFee = 10
            };
            Balance NewAccountBalance = new Balance()
            {
                BalanceAmount = money
            };
            Account userAccount = new TransactionalAccount()
            {
                cardNumber = cardNumber,
                pin = pin,
                AccountBalance = NewAccountBalance
            };
            accountRepository.addAccountToRepository(userAccount);
            return userAccount;
        }
    }
}
