using ApplicationLogic.Abstractions;
using ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(BankDbContext dbContext) : base(dbContext)
        {

        }
        public Account GetAccountByUserId(Guid userId)
        {
            var account = dbContext.Accounts
                         .Where(c => c.AccountID == userId)
                         .SingleOrDefault();
            return account;
        }
    }
}
