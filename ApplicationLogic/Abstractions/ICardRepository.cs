using ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Abstractions
{
    public interface ICardRepository
    {
        Card GetCardByUserId(Guid userId);
        Card Add(Card itemToAdd);
        IEnumerable<Card> GetAll();
    } 
}
