using ApplicationLogic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace DataAccess.Repositories
{
    public class TransactionRepository : ITransactionRepository 
    {
        //public TransactionRepository(BankDbContext dbContext) : base(dbContext)
        //{

        //}
        //    public Transaction GetTransactionByUserId(Guid userId)
        //    {
        //        var transaction = dbContext.Transactions
        //                     .Where(t => t.TransactionID == userId)
        //                     .SingleOrDefault();
        //        return transaction;
        //    }
    }
}
