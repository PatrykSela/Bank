using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Account
    {
        #region variables
        private string login;

        private string password;

        private float balance;

        private string history = "";

        private bool activate = true;

        private bool creaditavailable = true;

        private float creditvalue = 0;

        private bool admin = false;
        #endregion

        public Account(string login, string password, float balance)
        {
            this.login = login;
            this.password = password;
            this.balance = balance;
        }
        public Account(string login, string password,string state)
        {
            this.login = login;
            this.password = password;
            if (state=="Admin")
            {
                this.admin = true;
            }
        }
        #region prop
        public float CreditValue
        {
            get { return creditvalue; }
            set { creditvalue = value; }
        }

        public bool CreditAvailable
        {
            get { return creaditavailable; }
            set { creaditavailable = value; }
        }
        public string History
        {
            get { return history; }
            set { history = value; }
        }
        public bool Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        public bool Activate
        {
            get { return activate; }
            set { activate = value; }
        }

        public float Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        #endregion

    }
}
