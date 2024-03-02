using MediatR;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Applicaton.CarWorkshop;
using System.Globalization;
using CarWorkshop.Applicaton.CarWorkshop.Queries.GetAllCarWorkshops;
using CarWorkshop.Applicaton.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Applicaton.CarWorkshop.Queries.GetCarworkshopByEncodedName;
using AutoMapper;
using CarWorkshop.Applicaton.CarWorkshop.Commands.EdltCarWorkshop;
using Microsoft.AspNetCore.Authorization;

namespace CarWorkshop.MVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CarWorkshopController(IMediator mediator, IMapper mapper) 
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async  Task<IActionResult> Index()
        {
            var carWorkshops = await _mediator.Send(new GetAllCarWorkshopsQuery());
            return View(carWorkshops);
        }

        [Route("CarWorkshop/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName) 
        {
            var dto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));
            return View(dto);
        }

        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));

            if (!dto.IsEditable) 
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditCarWorkshopCommand model = _mapper.Map<EditCarWorkshopCommand>(dto);

            return View(model);
        }

        [HttpPost]
        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditCarWorkshopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public IActionResult Create() 
        { 
            return View(); 
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCarworkshopCommand command) 
        {
            if (!ModelState.IsValid) 
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
