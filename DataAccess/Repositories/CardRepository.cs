using ApplicationLogic.Abstractions;
using ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(BankDbContext dbContext) : base(dbContext)
        {

        }
        public Card GetCardByCardId(Guid cardId)
        {
            return dbContext.Cards
                            .Where(card => card.CardID == cardId)
                            .SingleOrDefault();
        }

    }
}
