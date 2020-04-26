using ApplicationLogic.Abstractions;
using ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using static ApplicationLogic.DataModel.Card;

namespace ApplicationLogic.Services
{
    public class CardService
    {
        private readonly ICardRepository cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            this.cardRepository = cardRepository;
        }

        public Card Add(string ownerName, string serialNumber, DateTime expiryDate, string cvv, CardType type)
        {
            var product = Card.Create(ownerName, serialNumber, expiryDate, cvv, type);

            return cardRepository.Add(product);
        }

        public IEnumerable<Card> GetAll()
        {
            return cardRepository.GetAll();
        }
    }
}
