using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KloudCodingTask.Model.CarOwnerModel;

namespace KloudCodingTask.UnitTest
{
    public static class TestHelper
    {
        public static List<Owner> GetCarOwnersFromFile()
        {
            using (StreamReader file = File.OpenText(@"carOwners.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Owner> myresult =
                    (List<Owner>)serializer.Deserialize(file, typeof(List<Owner>));

                return myresult;
            }
        }
    }
}
