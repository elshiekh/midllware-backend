﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mowadhafi_In.DTO;
using Mowadhafi_In.Helper;

namespace Mowadhafi_In.Service
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            //----DEVELOPMENT--------
             new User { Id = 1, FirstName = "e-PharmacyIn", LastName = "User", Username = "MowadhafiIn", Password = "mU1234" }
            //----PRODUCTION--------
            //new User { Id = 1, FirstName = "elevatusIn", LastName = "User", Username = "elevatusIn", Password = "mK865W7X]V" }
        };

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            return user.WithoutPassword();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.Run(() => _users.WithoutPasswords());
        }
    }
}
