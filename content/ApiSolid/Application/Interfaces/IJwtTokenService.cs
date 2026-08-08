namespace SolidApiTemplate.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(Guid userId, string userName);
}
