using ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Abstractions
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetAccountByUserId(Guid userId);
        Account Add(Account itemToAdd);
        bool Delete(Account itemToDelete);
        Account Update(Account itemToUpdate);
        IEnumerable<Account> GetAll();
    }
}
