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

        public IEnumerable<Client> GetAll()
        {
            return clientRepository.GetAll();
        }

        public Client GetClientByClientId(string clientId)
        {
            Guid.TryParse(clientId, out Guid guidClientId);

            if (guidClientId == Guid.Empty)
            {
                throw new Exception("");
            }

            var client = clientRepository.GetClientByClientId(guidClientId);

            if (client == null)
            {
                //throw new ClientNotFoundException(client.Id);
            }

            return client;

        }

        public Client Add(string Name, string Surname, string Address, string PostalCode, string CNP,
            string Country, string City, string District, string PhoneNumber, string Mail)
        {
            var client = Client.Create(Name, Surname, Address, PostalCode, CNP, Country, City,
                            District, PhoneNumber, Mail);

            return clientRepository.Add(client);
        }
    }
}
