using ApplicationLogic.Abstractions;
using ApplicationLogic.DataModel;
using ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using static ApplicationLogic.DataModel.Card;

namespace ApplicationLogic.Tests.Services
{
    [TestClass]
    public class CardServiceTests
    {

        private Mock<ICardRepository> cardRepoMock = new Mock<ICardRepository>();
        private Guid existingCardId = Guid.Parse("8766ABCD-EFA5-CBA7-1050-DEF2080BEDC1");

        [TestInitialize]
        public void TestInitialize()
        {
            var card = new Card
            {
                CardID = existingCardId,
                OwnerName = "Alex",
                SerialNumber = "1234",
                ExpiryDate = DateTime.Today.AddYears(2),
                CVV = "357",
                Type = CardType.MasterCard
            };

            cardRepoMock.Setup(cardRepo => cardRepo.GetCardByCardId(existingCardId))
                            .Returns(card);
        }


        [TestMethod]
        public void GetCardByCardId_ThrowsException_WhenCardIdHasInvalidValue()
        {
            // Arrange
            var cardService = new CardService(cardRepoMock.Object);

            var badCardId = "dada dahdakfjkfngf jkl";
            // Act

            // Assert
            Assert.ThrowsException<Exception>(() => {
                cardService.GetCardByCardId(badCardId);
            });
        }

        [TestMethod]
        public void GetCardByCardId_Returns_CardWhenExists()
        {

            Exception throwException = null;
            var cardService = new CardService(cardRepoMock.Object);
            Card card = null;
            //act   
            try
            {
                card = cardService.GetCardByCardId(existingCardId.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(card);
        }
    }
}
