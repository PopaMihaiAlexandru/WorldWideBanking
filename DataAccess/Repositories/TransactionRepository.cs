using ApplicationLogic.Abstractions;
using ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace DataAccess.Repositories
{
    public class TransactionRepository : ITransactionRepository 
    {
        public TransactionRepository(BankDbContext dbContext) : base(dbContext)
        {

        }

        public ApplicationLogic.DataModel.Transaction Add(ApplicationLogic.DataModel.Transaction itemToAdd)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ApplicationLogic.DataModel.Transaction itemToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationLogic.DataModel.Transaction> GetAll()
        {
            throw new NotImplementedException();
        }

        public System.Transactions.Transaction GetTransactionByUserId(Guid userId)
            {
                var transaction = dbContext.Transactions
                             .Where(t => t.TransactionID == userId)
                             .SingleOrDefault();
                return transaction;
            }

        public ApplicationLogic.DataModel.Transaction Update(ApplicationLogic.DataModel.Transaction itemToUpdate)
        {
            throw new NotImplementedException();
        }

        Client ITransactionRepository.GetTransactionByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
