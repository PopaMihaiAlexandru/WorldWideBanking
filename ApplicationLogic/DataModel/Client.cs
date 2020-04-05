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


    }
}
