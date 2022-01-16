using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class LoginIN
    {

        public void LoginTab(ref List<Account> accountList)
        {
            bool during_login = true;
            while (during_login)
            {
                Console.Clear();
                Console.Write("Enter login: ");
                string tmp_login = Console.ReadLine();
                Console.Write("Enter password: ");
                string tmp_password = Console.ReadLine();

                foreach (var acc in accountList)
                {
                    if(acc.Login==tmp_login && acc.Password==tmp_password)
                    {
                        during_login = false;
                        var currnetAccount = acc;
                        if(acc.Activate==false)
                        {
                            Display.AccountDisactivated();
                        }
                        else
                        {
                            Display.LoginSuccess();
                            Logs(ref currnetAccount, "Login in " + DateTime.Now);
                            Session(ref currnetAccount,ref accountList);
                        }
                        break;
                    }
                }
                if(during_login==true)
                {
                    Display.WrongLogin();
                }
            }
        }

        private void Session(ref Account currenAcc,ref List<Account> Acclist)
        {
           bool session_up = true;
           while (session_up)
           {
                Display.UserOptions(currenAcc.Admin);
                if(currenAcc.Admin)
                {
                    switch ((char)Console.ReadKey().Key)
                    {
                        case '1':
                            LockAccount(ref Acclist);
                            break;                         
                        case '2':
                            AddorRemove(ref Acclist);                          
                            break;
                        case '3':
                            BankInfo(Acclist);
                            break;
                        case '4':
                            ShowDebetors(Acclist);
                            break;
                        case '5':
                            session_up = false;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch ((char)Console.ReadKey().Key)
                    {
                        case '1':
                            WithrawORDeposit(ref currenAcc);
                            break;
                        case '2':
                            History(currenAcc.History);
                            break;
                        case '3':
                            Credit(ref currenAcc);
                            break;
                        case '4':
                            session_up = false;
                            Logs(ref currenAcc, "Log out " + DateTime.Now);
                            break;
                        default:
                            break;
                    }
                }
           }
        }
        //admin
        private void BankInfo(List<Account> Acclist)
        {
            int accAmount = 0;
            int credits = 0;
            float creditvalue = 0;
            float cash = 0;
            foreach (var item in Acclist)
            {
                accAmount++;
                cash += item.Balance;
                if (item.CreditAvailable == false)
                {
                    credits++;
                    creditvalue += item.CreditValue;
                }              
            }
            Console.WriteLine("\tBank info:");
            Console.Write($"Accounts:\t{accAmount}\n" +
                $"Credits amount:\t{credits}\n" +
                $"Value of Credits:\t{creditvalue}\n" +
                $"Amount of cash:\t{cash}");
            Console.ReadKey();
        }
        private void ShowDebetors(List<Account> Acclist)
        {
            Console.WriteLine("\tLogin\tPassword\tCreditValue");
            foreach (var item in Acclist)
            {
                if(item.CreditAvailable==false)
                {
                    Console.WriteLine($"\t{item.Login}\t{item.Password}\t{item.CreditValue}");
                }
            }
            Console.ReadKey();
        }
        private void LockAccount(ref List<Account> Acclist)
        {
            Console.WriteLine("Enter Login to lock acc");
            string l = Console.ReadLine();
            var selectAcc = Acclist.SingleOrDefault(x => x.Login == l);
            if (selectAcc != null) selectAcc.Activate = false;
        }
        private void AddorRemove(ref List<Account> Acclist)
        {
            Display.AddRemoveMenu();
            switch ((char)Console.ReadKey().Key)
            {
                case '1':
                    Display.AddAccount();
                    string s = Console.ReadLine();
                    string p = Console.ReadLine();
                    int b = int.Parse(Console.ReadLine());
                    Acclist.Add(new Account(s, p, b));
                    break;
                case '2':
                    Display.RemoveAcc();
                    string l = Console.ReadLine();
                    var item = Acclist.SingleOrDefault(x => x.Login == l);
                    if (item != null) Acclist.Remove(item);
                    break;
                default:
                    break;
            }
        }
        //User
        private void History(string history)
        {
            Console.Clear();
            Console.WriteLine(history);
            Console.ReadKey();
        }

        private void Logs(ref Account acc, string acction)
        {
            acc.History += $"\n{acction}";
        }
        private void WithrawORDeposit(ref Account acc)
        {
            Display.DeisplayWithdrawInfo();
            int v = int.Parse(Console.ReadLine());
            acc.Balance += v;
            Console.WriteLine("operation completed");
            Logs(ref acc, $"Account balance changed by {v}$");
            Console.ReadKey();
        }
        private void Credit(ref Account acc)
        {
            if (acc.CreditAvailable==false)
            {
                Logs(ref acc, "Creadit check and refused");
                Console.WriteLine("You cant take credit");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Enter the value of your credit");
                int v = int.Parse(Console.ReadLine());
                acc.CreditValue = v;
                acc.CreditAvailable = false;
                Console.WriteLine("Operation completed");
                Logs(ref acc, $"Credit check and get credit for {v}$");
            }
        }
    }
}
