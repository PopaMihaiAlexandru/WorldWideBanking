using ApplicationLogic.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ApplicationLogic.Tests.DataModel
{
    [TestClass]
    public class ClientTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            //this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Client CreateClient()
        {
            return new Client();
        }

        [TestMethod]
        public void Create_Returns_ValidAccountObject()
        {
            // Arrange
            var client = this.CreateClient();
            string name = "Peri";
            string surname = "Mihai";
            string address = "st. unu, nr. 4";
            string postalCode = "123456";
            string CNP = "1234567890123";
            string country = "Romania";
            string city = "Craiova";
            string district = "CV";
            string phoneNumber = "0123456789";
            string mail = "peri@peri.com";

            // Act
            var result = Client.Create(
                name,
                surname,
                address,
                postalCode,
                CNP,
                country,
                city,
                district,
                phoneNumber,
                mail
                );

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(Guid.Empty, result.ClientID);
            Assert.AreEqual(name, result.Name);
            Assert.AreEqual(surname, result.Surname);
            Assert.AreEqual(address, result.Address);
            Assert.AreEqual(postalCode, result.PostalCode);
            Assert.AreEqual(CNP, result.CNP);
            Assert.AreEqual(country, result.Country);
            Assert.AreEqual(city, result.City);
            Assert.AreEqual(district, result.District);
            Assert.AreEqual(phoneNumber, result.PhoneNumber);
            Assert.AreEqual(mail, result.Mail);
            Assert.IsNotNull(result.Accounts);
        }
    }
}
