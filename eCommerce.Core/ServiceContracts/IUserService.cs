using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;

/// <summary>
/// Contract for user service that contains use cases for users
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Method to handle login use case and returns an AuthenticationResponse object that contains status of login
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);


    /// <summary>
    /// Method to handle user registration use case and returns an AuthenticationResponse object that represents status of user registration  
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
}
