using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3_tasks.Entities
{
    internal class Transaction
    {
        private string _transactionId;
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public string Note { get; private set; }

        public Transaction(decimal amount, string note)
        {
            _transactionId = Guid.NewGuid().ToString();
            Amount = amount;
            Date = DateTime.Now;
            Note = note;
        }

        public override string ToString()
        {
            return $"{_transactionId} - {Date} - {Amount} - {Note}";
        }
    }
}
