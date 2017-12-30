using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KloudCodingTask.Model
{
    public class CarOwnerModel
    {
        public class Car
        {
            public string brand { get; set; }
            public string colour { get; set; }
        }

        public class Owner
        {
            public string name { get; set; }
            public List<Car> cars { get; set; }
        }

        public class CarOwner
        {
            public string name { get; set; }
            public string brand { get; set; }
            public string colour { get; set; }
        }
    }
}
