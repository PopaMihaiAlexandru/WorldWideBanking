using ApplicationLogic.Abstractions;
using ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Services
{
    public class ClientService
    {
        private readonly IClientRepository clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public Client GetClientByUserId(string userId)
        {
            Guid guidUserId = Guid.Empty;
            Guid.TryParse(userId, out guidUserId);

            if (guidUserId == Guid.Empty)
            {
                throw new Exception("");
            }

            var client = clientRepository.GetClientByUserId(guidUserId);

            if (client == null)
            {
                //throw new ClientNotFoundException(client.Id);
            }

            return client;

        }
    }
}
