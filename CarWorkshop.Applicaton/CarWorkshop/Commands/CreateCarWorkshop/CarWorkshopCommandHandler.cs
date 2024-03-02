using AutoMapper;
using CarWorkshop.Applicaton.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Applicaton.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateCarworkshopCommand>
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateCarWorkshopCommandHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper, IUserContext userContext) 
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateCarworkshopCommand request, CancellationToken cancellation) 
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(request);
            carWorkshop.EncodeName();

            carWorkshop.CreatedById = _userContext.GetCurrentUser().Id;

            await _carWorkshopRepository.Create(carWorkshop);

            return Unit.Value;
        }
    }
}
