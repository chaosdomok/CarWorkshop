using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Applicaton.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandValidator : AbstractValidator<CreateCarworkshopCommand>
    {
        public CreateCarWorkshopCommandValidator(ICarWorkshopRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Podaj Imię")
                .MinimumLength(2).WithMessage("Imię musi mieć conamniej 2 znaki")
                .MinimumLength(20).WithMessage("Imię może mieć maksymalnie 20 znaków")
                .Custom((value, context) =>
                {
                    var existingCarWorkshop = repository.GetByName(value).Result;
                    if (existingCarWorkshop != null)
                    {
                        context.AddFailure($"{value} istnieje już w bazie danych");
                    }
                });
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Podaj opis");
            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);

        }
    }
}
