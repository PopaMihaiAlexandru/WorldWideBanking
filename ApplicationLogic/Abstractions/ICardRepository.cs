using ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Abstractions
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetAll();
        Card GetCardByCardId(Guid cardId);
        Card Add(Card itemToAdd);
        bool Delete(Card itemToDelete);
        Card Update(Card itemToUpdate);
    } 
}
