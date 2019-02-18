using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign
{
    class Program
    {
        public static Account MakeAccount()
        {
            Console.WriteLine("\nEnter card number");
            string CardNumber = Console.ReadLine();
            Console.WriteLine("\nEnter pin");
            int pinNumber = Int32.Parse(Console.ReadLine());
            Account ATMuser = new TransactionalAccount();
            CardNumber cardNumber = new CardNumber()
            {
                cardNumber = CardNumber
            };
            Pin Pin = new Pin()
            {
                pin = pinNumber
            };
            Account account = ATMuser.makeAccount(cardNumber, Pin);

            Console.WriteLine("\nEnter card holder details:");
            Console.Write("Name:");
            string Name = Console.ReadLine();
            Console.Write("Age:");
            int Age = Int32.Parse(Console.ReadLine());
            Console.Write("Address:");
            string Address = Console.ReadLine();
            Console.Write("Email:");
            string Email = Console.ReadLine();
            CardHolder cardHolder = new CardHolder();
            cardHolder.CreateNewCardHolder(Name, Age, Address, Email, account);
            return account;
        }

        public static Account Login()
        {
            Account account = new TransactionalAccount();
            Console.WriteLine("\nEnter card number");
            string CardNumber = Console.ReadLine();
            Console.WriteLine("\nEnter pin");
            int pinNumber = Int32.Parse(Console.ReadLine());
            CardNumber cardNumber = new CardNumber()
            {
                cardNumber = CardNumber
            };
            Pin Pin = new Pin()
            {
                pin = pinNumber
            };
            return account.Login(cardNumber, Pin);
        }

        static void Main(string[] args)
        {
            Account UserAccount = new TransactionalAccount();
            Start:
            Console.WriteLine("1. Make account \n 2. Login");
            ConsoleKey userChoice = Console.ReadKey().Key;
            if(userChoice == ConsoleKey.D1)
            {
                UserAccount = MakeAccount();
            }
            else if(userChoice == ConsoleKey.D2)
            {
                UserAccount = Login();
            }
            if(UserAccount != null)
            {
                ConsoleKey transactionInput = ConsoleKey.D1;
                do
                {
                    Console.WriteLine("\n1- Check balance/n 2- Deposit cash/n 3- Withdraw cash/n 4- Transfer cash/n 5- Logout");
                    transactionInput = Console.ReadKey().Key;
                    switch (transactionInput)
                    {
                        case ConsoleKey.D1:
                            NonCashTransaction CheckBalanceTransaction = new CheckBalanceTransaction();
                            CheckBalanceTransaction.process(UserAccount);
                            break;
                        case ConsoleKey.D2:
                            CashTransaction DepositCashTransaction = new DepositCashTransaction();
                            Console.Write("\nAmount to deposit: ");
                            int amountToDeposit = Int32.Parse(Console.ReadLine());
                            Money DepositAmount = new Dollar()
                            {
                                amount = amountToDeposit
                            };

                            DepositCashTransaction.process(UserAccount, DepositAmount);
                            break;
                        case ConsoleKey.D3:
                            CashTransaction WithdrawTransaction = new WithdrawCashTransaction();
                            Console.Write("\nAmount to withdraw: ");
                            int amountToWithdraw = Int32.Parse(Console.ReadLine());
                            Money WithdrawAmount = new Dollar()
                            {
                                amount = amountToWithdraw
                            };
                            WithdrawTransaction.process(UserAccount, WithdrawAmount);

                            break;
                        case ConsoleKey.D4:
                            CashTransaction TransferCashTransaction = new TransferCashTransaction();
                            Console.Write("\nAmount to transfer: ");
                            int amountToTransfer = Int32.Parse(Console.ReadLine());
                            Money TransferAmount = new Dollar()
                            {
                                amount = amountToTransfer
                            };
                            TransferCashTransaction.process(UserAccount, TransferAmount);

                            break;
                        default:
                            Console.WriteLine("\nBreak");
                            break;
                    }
                } while (transactionInput != ConsoleKey.D5);
            }
            else
            {
                Console.WriteLine("\nAccount not found");
            }
            goto Start;

            
        }
        
    }
}
