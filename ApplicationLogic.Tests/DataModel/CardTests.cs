using ApplicationLogic.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using static ApplicationLogic.DataModel.Card;

namespace ApplicationLogic.Tests.DataModel
{
    [TestClass]
    public class CardTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Card CreateCard()
        {
            return new Card();
        }

        [TestMethod]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var card = this.CreateCard();
            string ownerName = null;
            string serialNumber = null;
            DateTime expiryDate = default(global::System.DateTime);
            string cvv = null;
            CardType type = default(global::ApplicationLogic.DataModel.Card.CardType);

            // Act
            var result = card.Create(
                ownerName,
                serialNumber,
                expiryDate,
                cvv,
                type);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
