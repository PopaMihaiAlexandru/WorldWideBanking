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
        public Transaction GetTransactionByTransactionId(string transactionId)
        {
            Guid guidTransactionId = Guid.Empty;
            Guid.TryParse(transactionId, out guidTransactionId);

            if (guidTransactionId == Guid.Empty)
            {
                throw new Exception("");
            }

            var transaction = transactionRepository.GetTransactionByTransactionId(guidTransactionId);

            if (transaction == null)
            {
                //throw new ClientNotFoundException(client.Id);
            }

            return transaction;

        }
    }
}
