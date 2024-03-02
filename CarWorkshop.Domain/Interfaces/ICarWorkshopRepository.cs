using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopRepository
    {
        Task Create(Entities.CarWorkshop carWorkshop);
        Task<Entities.CarWorkshop?> GetByName(string name);
        Task<IEnumerable<Entities.CarWorkshop>> GetAll();
        Task<Entities.CarWorkshop> GetByEncodedName(string encodedName);
        Task Commit();
    }
}
