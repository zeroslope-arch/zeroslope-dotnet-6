using ZeroSlope.Domain.Services;
using ZeroSlope.Models.Authentication.Requests;
using ZeroSlope.Models.Authentication.Responses;
using ZeroSlope.Packages.DotNet.Exceptions;

namespace ZeroSlope.Api.Routes
{
    public static class AuthRoutes
    {
        private const string Tag = "Auth";

        public static void useAuthRoutes(this WebApplication app)
        {
            app
                .MapPost("/api/auth/authenticate", [AllowAnonymous] (TokenRequest request, AuthService service, ContainerSettings settings) =>
                {
                    var token = service.Login(settings.Token.Secret, settings.Token.Issuer, request.EmailAddress, request.Password);
                    return Results.Ok(new TokenResponse()
                    {
                        Token = token
                    });
                })
                .WithTags(Tag)
                .Produces<TokenResponse>(200)
                .Produces<HandledResponseModel>(400)
                .Produces<HandledResponseModel>(500);
        }
    }
}
