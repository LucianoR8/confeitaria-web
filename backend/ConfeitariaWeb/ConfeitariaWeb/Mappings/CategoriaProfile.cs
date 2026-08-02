using AutoMapper;
using ConfeitariaWeb.Models;
using ConfeitariaWeb.DTOs.Categoria;
using ConfeitariaWeb.DTOs;

namespace ConfeitariaWeb.Mappings
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaResponseDto>()
            .ForMember(
                dest => dest.QuantidadeProdutos,
                opt => opt.MapFrom(src => src.Produtos.Count)
            );
            CreateMap<CategoriaCreateDto, Categoria>();
            CreateMap<CategoriaUpdateDto, Categoria>();
        }
    }
}