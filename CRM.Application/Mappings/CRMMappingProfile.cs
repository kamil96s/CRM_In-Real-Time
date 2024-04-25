using AutoMapper;
using CRM.Application.ApplicationUser;
using CRM.Application.CRM;
using CRM.Application.CRM.Commands.EditCRM;
using CRM.Application.CRMService;
using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Mappings
{
    public class CRMMappingProfile : Profile
    {
        public CRMMappingProfile(IUserContext userContext) 
        {

            var user = userContext.GetCurrentUser();
            CreateMap<CRMDto, Domain.Entities.CRM>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(scr => new CRMContactDetails()
                {
                City = scr.City,
                PhoneNumber = scr.PhoneNumber,
                PostalCode = scr.PostalCode,
                Street = scr.Street,
                }));

            CreateMap<Domain.Entities.CRM, CRMDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && (src.CreatedById == user.Id || user.IsInRole("Moderator"))))
                .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
                .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber));

            CreateMap<CRMDto, EditCRMCommand>();

            CreateMap<CRMServiceDto, Domain.Entities.CRMService>()
                .ReverseMap();
        }
    }
}
