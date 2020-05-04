using ApplicationLogic.Abstractions;
using ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class EFClientRepository : BaseRepository<Client>, IClientRepository
    {
        public EFClientRepository(BankDbContext dbContext) : base(dbContext)
        {

        }
        public Client GetClientByClientId(Guid clientId)
        {
            var client = dbContext.Clients
                         .Where(c => c.ClientID == clientId)
                         .SingleOrDefault();
            return client;
        }
    }
}
