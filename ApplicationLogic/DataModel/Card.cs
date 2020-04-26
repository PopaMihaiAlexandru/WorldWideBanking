using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.DataModel
{
    public class Card
    {
        public enum CardType
        {
            MasterCard,
            VISA
        }
        public Guid CardID { get; set; }
        public string OwnerName { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CVV { get; set; }
        public CardType Type { get; set; }

        public static Card Create(string ownerName, string serialNumber, DateTime expiryDate, string cvv, CardType type )
        {
            Card card = new Card
            {
                CardID = Guid.NewGuid(),
                OwnerName = ownerName,
                SerialNumber = serialNumber,
                ExpiryDate = expiryDate,
                CVV = cvv,
                Type = type
            };
            return card;
        }
    }
}
