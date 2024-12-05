namespace DataAccess.Models;

public class RefreshToken(string token)
{
    public string Token { get; set; } = token;
    public DateTime Expires { get; set; } = DateTime.Now.AddDays(10);
}
