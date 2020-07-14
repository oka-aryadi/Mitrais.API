using Mitrais.Data.Domain;
using Mitrais.Data.Request;
using System;
using System.Threading.Tasks;

namespace Mitrais.Interface
{
    public interface IUserService
    {
        Task<User> PostUserAsync(PostUser postUser);
        Task<User> GetUserAsync(UserFilter userFilter);
    }
}
