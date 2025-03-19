using AutoMapper;
using SovosProject.Application.Models;
using SovosProject.Core.Aggregates.Entities;

namespace SovosProject.Application.AutoMappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<InvoiceHeader, InvoiceHeaderDto>()
          .ForMember(dest => dest.InvoiceLines, opt => opt.MapFrom(src => src.InvoiceLines));

            CreateMap<InvoiceLine, InvoiceLineDto>();

            CreateMap<InvoiceHeaderDto, InvoiceHeader>()
       .ForMember(dest => dest.InvoiceLines, opt => opt.MapFrom(src => src.InvoiceLines))
       .ForMember(dest => dest.Id, opt => opt.Ignore()); // ID'yi DB belirleyecek

            CreateMap<InvoiceLineDto, InvoiceLine>()
          .ForMember(dest => dest.Id, opt => opt.Ignore());// ID'yi DB belirleyecek
        }

    }
}
