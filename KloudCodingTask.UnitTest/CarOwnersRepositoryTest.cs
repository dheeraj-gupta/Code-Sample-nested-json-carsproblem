using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KloudCodingTask.DataAccessLayer;
using KloudCodingTask.Model;

namespace KloudCodingTask.UnitTest
{
    [TestClass]
    public class CarOwnersRepositoryTest
    {
        [TestMethod]
        public void CheckBackedServiceIsUp()
        {
            // Arrange
            CarOwnersRepository repository = new CarOwnersRepository();
            // Act
            var peopleList = repository.GetCarOwnersList();
            // Assert
            Assert.IsNotNull(peopleList);
            Assert.IsTrue(peopleList.Count > 0);
        }
    }
}
