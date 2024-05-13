using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3_tasks.Entities
{
    internal class BankAccount
    {
        private string _accountId;
        private string _owner;
        private decimal _balance = 0;
        private List<Transaction> _allTransactions = new List<Transaction>();

        public BankAccount(string owner, decimal initialBalance)
        {
            _accountId = GenerateId();
            Owner = owner;
            Balance = initialBalance;
        }

        public string Owner
        {
            get => _owner;
            private set
            {

                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentOutOfRangeException($" {nameof(Owner)} should not be empty");
                _owner = value;
            }
        }

        public decimal Balance
        {
            get => _balance;
            private set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                _balance = value;
            }
        }

        public void MakeDeposite(decimal amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException("Deposit amount should be positive value");

            Balance += amount;
            Transaction depositTransaction = new Transaction(amount, $"{amount} mebleginde medaxil emeliyyati icra olundu. Balans: {Balance}");
            _allTransactions.Add(depositTransaction);
        }

        public void MakeWithdrawal(decimal amount)
        {
            Transaction withdrawalTransaction;

            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
            if (amount > Balance)
            {
                withdrawalTransaction = new Transaction(amount, $"{amount} mebleginde mexaric emeliyyati ugursuz oldu. Balansdan pul chixarila bilmedi. Cari Balans: {Balance}");
                _allTransactions.Add(withdrawalTransaction);
                throw new ArgumentOutOfRangeException("There is no enough funds");
            }
            else
            {
                Balance -= amount;
                withdrawalTransaction = new Transaction(amount, $"{amount} mebleginde mexaric emeliyyati icra olundu. Cari Balans: {Balance}");
                _allTransactions.Add(withdrawalTransaction);
            }
        }

        public string GetTransactions()
        {
            string output = "";

            foreach (Transaction transaction in _allTransactions)
            {
                output += $"{transaction.ToString()}\n";
            }

            return output;
        }

        static string GenerateId()
        {
            Random random = new Random();
            string id = "";

            for (int i = 0; i <= 10; i++)
            {

                id += random.Next(0, 9);
            }

            return id;
        }
    }
}
