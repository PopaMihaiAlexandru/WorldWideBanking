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

        [TestInitialize]
        public void TestInitialize()
        {
            //this.mockRepository = new MockRepository(MockBehavior.Strict);


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
            string ownerName = "Alex";
            string serialNumber = "ned3421213";
            DateTime expiryDate = DateTime.Today.AddYears(2);
            string cvv = "123";
            CardType type = CardType.MasterCard;

            // Act
            var result = Card.Create(
                ownerName,
                serialNumber,
                expiryDate,
                cvv,
                type);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(Guid.Empty, result.CardID);
            Assert.AreEqual(ownerName, result.OwnerName);
            Assert.AreEqual(serialNumber, result.SerialNumber);
            Assert.AreEqual(expiryDate, result.ExpiryDate);
            Assert.AreEqual(cvv, result.CVV);
            Assert.AreEqual(type, result.Type);
        }

        [TestMethod]
        public void Create_StateUnderTest_UnexpectedBehavior()
        {
            // Arrange
            var card = this.CreateCard();
            string ownerName = "Alex";
            string serialNumber = "ned3421213";
            DateTime expiryDate = DateTime.Today.AddYears(2);
            string cvv = "123";
            CardType type = CardType.MasterCard;

            // Act
            var result = Card.Create(
                ownerName,
                serialNumber,
                expiryDate,
                cvv,
                type);

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(Guid.Empty, result.CardID);
            Assert.AreNotEqual(ownerName, result.OwnerName);
            Assert.AreNotEqual(serialNumber, result.SerialNumber);
            Assert.AreNotEqual(expiryDate, result.ExpiryDate);
            Assert.AreNotEqual(cvv, result.CVV);
            Assert.AreNotEqual(type, result.Type);
        }
    }
}
