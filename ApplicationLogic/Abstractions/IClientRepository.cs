using ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Abstractions
{
    public interface IClientRepository : IRepository<Client>
    {
        Client GetClientByUserId(Guid userId);
    }
}
