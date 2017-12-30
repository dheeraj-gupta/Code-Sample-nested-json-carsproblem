using KloudCodingTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KloudCodingTask.DataAccessLayer
{
    public interface ICarOwnersRepository
    {
        List<CarOwnerModel.Owner> GetCarOwnersList();
    }
}
