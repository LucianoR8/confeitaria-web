using ConfeitariaWeb.Services;
using ConfeitariaWeb.Models;
using ConfeitariaWeb.Repositories;
using ConfeitariaWeb.Repositories.Interface;
using ConfeitariaWeb.Repositories.Interfaces;
using ConfeitariaWeb.Services.Interface;
using ConfeitariaWeb.Services.Interfaces;

namespace ConfeitariaWeb.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IConfiguracaoRepository, ConfiguracaoRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        services.AddScoped<ICategoriaService, CategoriaService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IConfiguracaoService, ConfiguracaoService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddHttpClient<IImageStorageService, ImageStorageService>();

        return services;
    }
}
