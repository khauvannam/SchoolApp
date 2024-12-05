namespace Presentation.DTOs;

public class AccessTokenDto(string token)
{
    public string Token { get; set; } = token;
    public DateTime Expires { get; set; } = DateTime.UtcNow.AddDays(1);
}
