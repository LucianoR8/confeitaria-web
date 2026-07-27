using Scalar.AspNetCore;

namespace ConfeitariaWeb.Extensions;

public static class OpenApiExtensions
{
    public static WebApplication UseApiDocumentation(
        this WebApplication app)
    {
        app.MapOpenApi();

        app.MapScalarApiReference(options =>
        {
            options.Title = "Confeitaria Web API";
        });

        return app;
    }
}