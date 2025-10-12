using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;


/// <summary>
/// Contact to be implemented by UserRepository that contains data access logic of user data store
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Method to add user to the data store and return the added user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<ApplicationUser> AddUser(ApplicationUser user);


    /// <summary>
    /// Method to retreive existing user by their email and password
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
}
