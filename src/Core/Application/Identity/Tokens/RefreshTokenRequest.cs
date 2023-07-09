namespace EFManager.API.Application.Identity.Tokens;

public record RefreshTokenRequest(string Token, string RefreshToken);