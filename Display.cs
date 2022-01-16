using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class Display
    {
        public static void StartScreen()
        {
            Console.Clear();
            Console.Write(
                "\tOptions\n" +
                "\t1)Login\n" +
                "\t2)Exit\n");
        }
        public static void WrongLogin()
        {
            Console.Clear();
            Console.WriteLine("Inncorrect login or password");
            Console.ReadKey();
        }
        public static void LoginSuccess()
        {
            Console.Clear();
            Console.WriteLine("You logged in");
            Console.ReadKey();
        }
        public static void AccountDisactivated()
        {
            Console.Clear();
            Console.WriteLine("Your account is inactive");
            Console.ReadKey();
        }
        public static void DeisplayWithdrawInfo()
        {
            Console.WriteLine("\nHow much u want to Deposit/Withdraw");
        }
        public static void AddRemoveMenu()
        {
            Console.Clear();
            Console.Write("Admin comsole :\n" +
                "1)add account\n" +
                "2)remove account\n" +
                "Press any key do go back");
            }
        public static void AddAccount()
        {
            Console.WriteLine("Enter Login ,Password, balance");
        }
        public static void RemoveAcc()
        {
            Console.WriteLine("Enter Login");
        }
        public static void UserOptions(bool permission)
        {
            if (permission)
            {
                Console.Clear();
                Console.Write("Admin comsole :\n" +
                    "1)lock account\n" +
                    "2)add/remove account\n" +
                    "3)Bank full info\n" +
                    "4)Show Debtors\n"+
                    "5)Log Out\n");

            }
            else
            {
                Console.Clear();
                Console.Write("User comsole :\n" +
                   "1)Deposit/Withdraw\n" +
                   "2)Account History\n" +
                   "3)Credit\n" +
                   "4)Log Out\n");
            }
        }
    }
}
