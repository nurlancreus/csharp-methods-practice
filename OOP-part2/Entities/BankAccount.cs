using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_part2.Entities
{
    internal class BankAccount
    {
        private string _id = Guid.NewGuid().ToString();
        private decimal _balance = 0;
        private decimal _loan = 0;
        private string _loanPurpose = "";

        public decimal Balance
        {
            get => _balance; set { _balance = value; }
        }

        public decimal Loan
        {
            get => _loan;
            private set { _loan = value; }
        }

        public string LoanPurpose
        {
            get => _loanPurpose;
            private set { _loanPurpose = value; }
        }

        public void Deposit(decimal value)
        {
            if (value < 0) throw new ArgumentException("Medaxil menfi ola bilmez");
            Balance += value;
        }

        public void WithDraw(decimal value)
        {
            if (value < 0) throw new ArgumentException("Mexaric menfi ola bilmez");
            Balance -= value;
        }
        public void GetLoan(decimal loan, string loanPurpose)
        {
            if (Loan == 0)
            {
                Loan = loan;
                Balance += loan;
                LoanPurpose = loanPurpose;
            }
            else Console.WriteLine("Sizin artiq kredit borcunuz var, ilk evvel onu odeyin");
        }

        public void PayLoan()
        {
            Balance -= Loan;
            Loan = 0;
            LoanPurpose = "";
        }
    }
}
