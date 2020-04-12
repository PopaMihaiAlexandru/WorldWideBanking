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
        
    }
}
