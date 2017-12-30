using KloudCodingTask.BusinessLayer;
using KloudCodingTask.DataAccessLayer;
using KloudCodingTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KloudCodingTask.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            GetOwnerListGroupedByCar();
            Console.ReadLine();
        }

       public static void GetOwnerListGroupedByCar()
        {
            CarOwnersBusiness carOwnersRepository = new CarOwnersBusiness(new CarOwnersRepository());

            var carOwnerListGroupedbyCar  = carOwnersRepository.GetListOfOwnersGroupedByCarsInAlphabaticalOrder();

            foreach (var group in carOwnerListGroupedbyCar)
            {
                Console.WriteLine(group.Key.ToUpper());
                foreach (var car in group.OrderBy(d => d.colour))
                {

                    Console.WriteLine($"\t{car.name} --> {car.colour}");
                }
            }
        }
    }
}
