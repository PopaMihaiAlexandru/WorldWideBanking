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
        public void Create_Returns_ValidClientObject()
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

        [TestMethod]
        public void Create_StateUnderTest_UnexpectedBehavior()
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
            Assert.ThrowsException<AssertFailedException>(() => {
                Assert.IsNull(result);
                Assert.AreEqual(Guid.Empty, result.ClientID);
                Assert.AreNotEqual(name, result.Name);
                Assert.AreNotEqual(surname, result.Surname);
                Assert.AreNotEqual(address, result.Address);
                Assert.AreNotEqual(postalCode, result.PostalCode);
                Assert.AreNotEqual(CNP, result.CNP);
                Assert.AreNotEqual(country, result.Country);
                Assert.AreNotEqual(city, result.City);
                Assert.AreNotEqual(district, result.District);
                Assert.AreNotEqual(phoneNumber, result.PhoneNumber);
                Assert.AreNotEqual(mail, result.Mail);
                Assert.IsNull(result.Accounts);
            });
        }
    }
}
