using Application.DTOs;
using Domain.Entities;
using Mapster;

namespace Application.Mapping
{
    public class MapsterConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<Product, ProductDto>()
                .Map(dest => dest.CategoryName, src => src.Category.Name);

            config.NewConfig<CreateProductDto, Product>();
        }
    }
}
