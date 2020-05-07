using ApplicationLogic.Abstractions;
using ApplicationLogic.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataAccess.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        private readonly BankDbContext _context;
        public TransactionRepository(BankDbContext dbContext) : base(dbContext)
        {
            this._context = dbContext;
        }

        public Transaction GetTransactionByTransactionId(Guid transactionId)
        {
            var transaction = dbContext.Transactions
                         .Where(t => t.TransactionID == transactionId)
                         .SingleOrDefault();
            return transaction;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
