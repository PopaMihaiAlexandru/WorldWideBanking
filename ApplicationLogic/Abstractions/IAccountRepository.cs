using ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Abstractions
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetAccountByUserId(Guid userId);
    }
}
