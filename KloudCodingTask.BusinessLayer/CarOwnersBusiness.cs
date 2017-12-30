using KloudCodingTask.DataAccessLayer;
using KloudCodingTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KloudCodingTask.BusinessLayer
{
    public class CarOwnersBusiness : ICarOwnersBusiness
    {

        public ICarOwnersRepository _carOwnersRepository { get; set; }
        public CarOwnersBusiness(ICarOwnersRepository carOwnersRepository)
        {
            this._carOwnersRepository = carOwnersRepository;
        }

        public IOrderedEnumerable<IGrouping<string, CarOwnerModel.CarOwner>> GetListOfOwnersGroupedByCarsInAlphabaticalOrder()
        {
            IOrderedEnumerable<IGrouping<string, CarOwnerModel.CarOwner>> carOwnerListGroupedbyCar = null;
            try
            {
                var carOwnersList =   this._carOwnersRepository.GetCarOwnersList();

                if (carOwnersList != null)
                {
                    try
                    {
                        var filteredCarOwnerbyBrand = GetFilteredCarOwner(carOwnersList);

                        var carbyOwnerflattenList = GetCarbyOwnerFlattenList(filteredCarOwnerbyBrand);

                        carOwnerListGroupedbyCar = GetListOfOwnersGroupedByCars(carbyOwnerflattenList);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("GetCatsByOwnerGender method failed" + ex.InnerException.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Service is down");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetListOfOwnersGroupedByCarsInAlphabaticalOrder failed " + ex.Message);
            }

            return carOwnerListGroupedbyCar;
        }

        private List<CarOwnerModel.Owner> GetFilteredCarOwner(List<CarOwnerModel.Owner> carOwnersList)
        {
            List<CarOwnerModel.Owner> filtedCarOwner = null;
            try
            {
                filtedCarOwner = carOwnersList.FindAll(x => !string.IsNullOrEmpty(x.name)
                             && x.cars != null && x.cars.Any(v => !string.IsNullOrEmpty(v.colour)));
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetFilteredCarOwner failed" + ex.Message);
                filtedCarOwner = null;
            }

            return filtedCarOwner;
        }

        private List<CarOwnerModel.CarOwner> GetCarbyOwnerFlattenList(List<CarOwnerModel.Owner> filteredCarOwnerbyBrand)
        {
            List<CarOwnerModel.CarOwner> carbyOwnerList = new List<CarOwnerModel.CarOwner>();
            try
            {
                foreach (var temp in filteredCarOwnerbyBrand)
                {
                    foreach (var temp2 in temp.cars)
                    {
                        CarOwnerModel.CarOwner carbyOwner = new CarOwnerModel.CarOwner();
                        carbyOwner.brand = temp2.brand;
                        carbyOwner.colour = temp2.colour;
                        carbyOwner.name = temp.name;
                        carbyOwnerList.Add(carbyOwner);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetCarbyOwnerflattenList failed" + ex.Message);
                carbyOwnerList = null;
            }

            return carbyOwnerList;
        }

        private IOrderedEnumerable<IGrouping<string, CarOwnerModel.CarOwner>> GetListOfOwnersGroupedByCars(List<CarOwnerModel.CarOwner> carbyOwnerflattenList)
        {
                return carbyOwnerflattenList.GroupBy(x => x.brand).OrderBy(k => k.Key);
            
        }
    }
}
