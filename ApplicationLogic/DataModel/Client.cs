using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.DataModel
{
    public class Client
    {
        public Guid ClientID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string CNP { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }

        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public ICollection<Account> Accounts { get; set; }

        public static Client Create(string name, string surname, string address, string postalCode, string CNP,
            string country, string city, string district, string phoneNumber, string mail)
        {
            Client client = new Client
            {
                ClientID = Guid.NewGuid(),
                Name = name,
                Surname = surname,
                Address = address,
                PostalCode = postalCode,
                CNP = CNP,
                Country = country,
                City = city,
                District = district,
                PhoneNumber = phoneNumber,
                Mail = mail,
                Accounts = new List<Account>()
            };
            return client;
        }
    }
}
