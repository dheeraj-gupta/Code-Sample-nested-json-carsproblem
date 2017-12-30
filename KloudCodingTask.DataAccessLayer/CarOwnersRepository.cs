using KloudCodingTask.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KloudCodingTask.DataAccessLayer
{
    public class CarOwnersRepository : ICarOwnersRepository
    {
        private const string EndPoint = "https://kloudcodingtest.azurewebsites.net/api/cars";
        public List<CarOwnerModel.Owner> GetCarOwnersList()
        {
            List<CarOwnerModel.Owner> carOwnerList = null;
            try
            {
                var http = new HttpClient();
                var url =String.Format(EndPoint);
                var response = http.GetAsync(url).Result;

                carOwnerList = JsonConvert.DeserializeObject<List<CarOwnerModel.Owner>>(response.Content.ReadAsStringAsync().Result);
            }

            catch (Exception ex)
            {
                Console.WriteLine("GetCarOwnersList failed " + ex.Message);
                //carOwnerList = GetCarOwnersListFromFile();
            }

            return carOwnerList;
        }
    }
}
