using AutoMapper;
using ConfeitariaWeb.Mappings;
using Microsoft.Extensions.Logging.Abstractions;

namespace ConfeitariaWeb.Extensions;

public static class AutoMapperExtensions
{
    public static IServiceCollection AddApplicationMappings(
        this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CategoriaProfile>();
            cfg.AddProfile<ProdutoProfile>();
            cfg.AddProfile<ConfiguracaoProfile>();
        }, NullLoggerFactory.Instance);

        services.AddSingleton(mapperConfig.CreateMapper());

        return services;
    }
}