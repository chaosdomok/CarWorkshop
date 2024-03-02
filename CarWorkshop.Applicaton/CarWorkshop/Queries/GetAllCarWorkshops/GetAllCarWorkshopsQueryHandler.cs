using AutoMapper;
using CarWorkshop.Applicaton.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Applicaton.CarWorkshop.Queries.GetAllCarWorkshops
{
    public class GetAllCarWorkshopsQueryHandler : IRequestHandler<GetAllCarWorkshopsQuery, IEnumerable<CarWorkshopDto>>
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IMapper _mapper;

        public GetAllCarWorkshopsQueryHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CarWorkshopDto>> Handle(GetAllCarWorkshopsQuery request, CancellationToken cancellation)
        {
            var carWorkshops = await _carWorkshopRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<CarWorkshopDto>>(carWorkshops);

            return dtos;
        }
    }
}
