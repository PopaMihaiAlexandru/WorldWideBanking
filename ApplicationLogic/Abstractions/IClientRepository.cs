using ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Abstractions
{
    public interface IClientRepository : IRepository<Client>
    {
        Client GetClientByUserId(Guid userId);
        Client Add(Client itemToAdd);
        bool Delete(Client itemToDelete);
        Client Update(Client itemToUpdate);
        IEnumerable<Client> GetAll();
    }
}
