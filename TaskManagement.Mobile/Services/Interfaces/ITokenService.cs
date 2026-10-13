namespace TaskManagement.Mobile.Services.Interfaces
{
    public interface ITokenService
    {
        Task SaveTokenAsync(string token);
        Task<string?> GetTokenAsync();
        Task RemoveTokenAsync();
    }
}
