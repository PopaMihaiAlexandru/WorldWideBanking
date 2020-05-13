using ApplicationLogic.Abstractions;
using ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Services
{
    public class AccountService
    {
        private readonly IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public Account GetAccountByAccountId(string accountId)
        {
            Guid guidAccountId = Guid.Empty;
            Guid.TryParse(accountId, out guidAccountId);

            if (guidAccountId == Guid.Empty)
            {
                throw new Exception("");
            }

            var account = accountRepository.GetAccountByAccountId(guidAccountId);

            if (account == null)
            {
                //throw new AccountNotFoundException(account.Id);
            }

            return account;

        }
    }
}
