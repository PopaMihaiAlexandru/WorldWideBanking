using ApplicationLogic.Abstractions;
using ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Services
{
    public class TransactionService
    {
        private readonly ITransactionRepository transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        //public Transaction GetTransactionByUserId(string userId)
        //{
        //    Guid guidUserId = Guid.Empty;
        //    Guid.TryParse(userId, out guidUserId);

        //    if (guidUserId == Guid.Empty)
        //    {
        //        throw new Exception("");
        //    }

        //    var transaction = transactionRepository.GetTransactionByUserId(guidUserId);

        //    if (transaction == null)
        //    {
        //        //throw new ClientNotFoundException(client.Id);
        //    }

        //    return transaction;

        //}
    }
}
