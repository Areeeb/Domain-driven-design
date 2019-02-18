using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign
{
    class AccountRepository
    {
        private List<Account> accountRepository = new List<Account>();

        public IReadOnlyCollection<Account> ATMaccounts { get { return this.accountRepository.AsReadOnly(); } }
        
        public void addAccountToRepository(Account userAccount)
        {
            accountRepository.Add(userAccount);
        }
    }
}
