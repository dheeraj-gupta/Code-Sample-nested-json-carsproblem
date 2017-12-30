using KloudCodingTask.BusinessLayer;
using KloudCodingTask.DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KloudCodingTask.Model.CarOwnerModel;

namespace KloudCodingTask.UnitTest
{
    [TestClass]
    public class CarOwnersBusinessTest
    {

        private Mock<ICarOwnersRepository> _carOwnersRepository;
        private Mock<ICarOwnersBusiness> _carOwnersBusiness;
        private List<Owner> _carOwnerList;

        [TestMethod]
        public void GetCarOwnersByCarsInAlphabaticalOrderThenByColourInAlphabaticalOrder()
        {

            // Arrange
            _carOwnersRepository = new Mock<ICarOwnersRepository>();
            _carOwnersBusiness = new Mock<ICarOwnersBusiness>();
            _carOwnerList = TestHelper.GetCarOwnersFromFile();

            //Act

            _carOwnersRepository.Setup(x => x.GetCarOwnersList()).Returns(() => _carOwnerList);
            CarOwnersBusiness catBusiness = new CarOwnersBusiness(_carOwnersRepository.Object);
            var result = catBusiness.GetListOfOwnersGroupedByCarsInAlphabaticalOrder();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any(x => x.Key == "BMW" && x.OrderBy(d => d.colour).Any(c => c.name == "Matilda")));
            Assert.IsTrue(result.Any(x => x.Key == "Holden" && x.OrderBy(d => d.colour).Any(c => c.name == "Andre")));
            Assert.IsTrue(result.Any(x => x.Key == "Mercedes" && x.OrderBy(d => d.colour).Any(c => c.name == "Kristin")));
            Assert.IsTrue(result.Any(x => x.Key == "Toyota" && x.OrderBy(d => d.colour).Any(c => c.name == "Iva")));

        }
    }
}
