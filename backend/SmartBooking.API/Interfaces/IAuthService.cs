namespace SmartBooking.API.Interfaces
{
    public interface IAuthService
    {
        Task SignUpAsync(string email,string firstName, string lastName, string password);
        Task<string?> SignInAsync(string email, string password);
    }
}
