using AutoMapper;
using SistemaVenda.Models;
using SistemaVenda.ViewModel;

namespace SistemaVenda.AutoMapper
{
    public class ConfigAutoMapper : Profile
    {
        public ConfigAutoMapper()
        {
            CreateMap<Product, ProductViewModel>()
                .ReverseMap();

            CreateMap<Batch, BatchViewModel>()
                .ReverseMap();
        }
    }
}
