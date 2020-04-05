using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.DataModel
{
    public class Transaction
    {
        public enum TransactionStatus
        {
            Processing,
            Approved,
            Declined
        }
        public Guid TransactionID { get; set; }
        public string SenderIBAN { get; set; }
        public string RecipentIBAN { get; set; }
        public int Amount { get; set; }
        public DateTime TransactionTime { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
