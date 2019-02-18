using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign
{
    class CardHolder
    {
        public Guid CardHolderId { get; protected set; }
        public string Name { get; protected set; }
        public int Age { get; protected set; }
        public string Address { get; protected set; }
        public string Email { get; protected set; }
        public Account account { get; protected set; }

        private List<CashTransaction> cashtransactions = new List<CashTransaction>();
        private List<NonCashTransaction> nonCashtransactions = new List<NonCashTransaction>();
        public IReadOnlyCollection<CashTransaction> CashTransactionList { get { return this.cashtransactions.AsReadOnly(); } }
        public IReadOnlyCollection<NonCashTransaction> NonCashTransactionList { get { return this.nonCashtransactions.AsReadOnly(); } }

        public void CreateNewCardHolder(string name, int age, string address, string email, Account acc)
        {
            CardHolder cardHolder = new CardHolder()
            {
                Name = name,
                Age = age,
                Address = address,
                Email = email,
                account = acc
            };
        }

        public void AddCardHolderCashTransactions(CashTransaction transaction)
        {
            cashtransactions.Add(transaction);
        }

        public void AddCardHolderNonCashTransactions(NonCashTransaction transaction)
        {
            nonCashtransactions.Add(transaction);
        }
    }
}
