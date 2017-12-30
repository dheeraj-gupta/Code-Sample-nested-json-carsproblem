using KloudCodingTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KloudCodingTask.BusinessLayer
{
    public interface ICarOwnersBusiness
    {
        IOrderedEnumerable<IGrouping< string , CarOwnerModel.CarOwner>> GetListOfOwnersGroupedByCarsInAlphabaticalOrder();
    }
}
