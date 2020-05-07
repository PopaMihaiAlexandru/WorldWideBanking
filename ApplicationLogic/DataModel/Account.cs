using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.DataModel
{
    public class Account
    {
        public Guid AccountID { get; set; }
        public string IBAN { get; set; }
        public string Balance { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

        public static Account Create(string IBAN, string balance)
        {
            Account account = new Account
            {
                AccountID = Guid.NewGuid(),
                IBAN = IBAN,
                Balance = balance
            };
            return account;
        }
    }
}
