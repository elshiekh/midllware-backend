using elevatus_out.DTO;
using elevatus_out.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elevatus_out.Service
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
            //new User { Id = 1, FirstName = "externalPortalIn", LastName = "User", Username = "externalPortalIn", Password = "mV24WX]N" }
            new User { Id = 1, FirstName = "elevatusOut", LastName = "User", Username = "elevatusOut", Password = "mR79WX]FV" }
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
