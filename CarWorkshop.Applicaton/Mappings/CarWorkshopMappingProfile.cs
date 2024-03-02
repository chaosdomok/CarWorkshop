using AutoMapper;
using CarWorkshop.Applicaton.ApplicationUser;
using CarWorkshop.Applicaton.CarWorkshop;
using CarWorkshop.Applicaton.CarWorkshop.Commands.EdltCarWorkshop;
using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Applicaton.Mappings
{
    internal class CarWorkshopMappingProfile : Profile 
    {
        public CarWorkshopMappingProfile(IUserContext userContext) 
        {
            var user = userContext.GetCurrentUser();
            CreateMap<CarWorkshopDto, Domain.Entities.CarWorkshop>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new CarWorkShopContact()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                }));

            CreateMap<Domain.Entities.CarWorkshop, CarWorkshopDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user  != null && src.CreatedById == user.Id))
                .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ContactDetails))
                .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails))
                .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails));


            CreateMap<CarWorkshopDto, EditCarWorkshopCommand>();
        }
    }
}
