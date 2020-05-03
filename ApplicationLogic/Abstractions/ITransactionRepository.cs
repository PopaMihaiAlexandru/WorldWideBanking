using ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Abstractions
{
    public interface ITransactionRepository : IDisposable
    {
        IEnumerable<Transaction> GetAll();
        Transaction GetTransactionByTransactionId(Guid transactionId);
        Transaction Add(Transaction itemToAdd);
        bool Delete(Transaction itemToDelete);
        Transaction Update(Transaction itemToUpdate);
    }
}
