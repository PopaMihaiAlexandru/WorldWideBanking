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
        public Card GetCardByUserId(Guid userId)
        {
            return dbContext.Cards
                            .Where(card => card.CardID == userId)
                            .SingleOrDefault();
        }

        public Card Add(Card itemToAdd)
        {
            var entity = dbContext.Add<Card>(itemToAdd);
            dbContext.SaveChanges();
            return entity.Entity;
        }

        public IEnumerable<Card> GetAll()
        {
            return dbContext.Set<Card>()
                            .AsEnumerable();
        }
    }
}
