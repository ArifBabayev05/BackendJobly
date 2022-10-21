using System;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Utilities.Abstract
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string userName, string password);
        Task<bool> UserExist(string userName);
    }
}

