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

        public Card GetCardByCardId(string cardId)
        {
            Guid guidCardId = Guid.Empty;
            Guid.TryParse(cardId, out guidCardId);

            if (guidCardId == Guid.Empty)
            {
                throw new Exception("");
            }

            var card = cardRepository.GetCardByCardId(guidCardId);

            if (card == null)
            {
                //throw new CardNotFoundException(card.Id);
            }

            return card;

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
