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

        public AccountService(IClientRepository clientRepository)
        {
            this.accountRepository = accountRepository;
        }

        public Account GetAccountByUserId(string userId)
        {
            Guid guidUserId = Guid.Empty;
            Guid.TryParse(userId, out guidUserId);

            if (guidUserId == Guid.Empty)
            {
                throw new Exception("");
            }

            var account = accountRepository.GetAccountByUserId(guidUserId);

            if (account == null)
            {
                //throw new AccountNotFoundException(account.Id);
            }

            return account;

        }
    }
}
