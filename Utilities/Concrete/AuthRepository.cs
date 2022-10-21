using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Utilities.Abstract;

namespace Utilities.Concrete
{
    public class AuthRepository : IAuthRepository
    {
        public readonly JoblyContext _joblyContext;
        public async Task<User> Login(string userName, string password)
        {
            var user = await _joblyContext.Users.FirstOrDefaultAsync(x=>x.FirstName==userName);
            if (user==null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
            {
                return null;

            }

            return user;


        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _joblyContext.Users.AddAsync(user);
            await _joblyContext.SaveChangesAsync();

            return user;

        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                
            }
        }

        public async Task<bool> UserExist(string userName)
        {
            if (await _joblyContext.Users.AnyAsync(u=>u.FirstName == userName))
            {
                return true;
            }
            return false;
        }
    }
}

