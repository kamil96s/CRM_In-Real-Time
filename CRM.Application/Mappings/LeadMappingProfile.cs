using AutoMapper;
using CRM.Application.ApplicationUser;
using CRM.Application.Lead;
using CRM.Application.Lead.Commands.Edit;
using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Mappings
{
    public class LeadMappingProfile : Profile
    {
        public LeadMappingProfile(IUserContext userContext) 
        {

            var user = userContext.GetCurrentUser();

            CreateMap<Domain.Entities.Lead, LeadDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && (src.CreatedById == user.Id))); // (src.CreatedById == user.Id || user.IsInRole("Moderator"))))

            CreateMap<LeadDto, EditLeadCommand>();
        }
    }
}
