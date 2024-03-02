using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Applicaton.CarWorkshop.Queries.GetAllCarWorkshops
{
    public class GetAllCarWorkshopsQuery : IRequest<IEnumerable<CarWorkshopDto>>
    {
    }
}
