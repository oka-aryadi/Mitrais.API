using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mitrais.Data;
using Mitrais.Data.Domain;
using Mitrais.Data.Request;
using Mitrais.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mitrais.Service
{
    public class UserService : IUserService
    {
        private DataContext _dataContext;
        private IMapper _mapper;

        public UserService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<User> PostUserAsync(PostUser postUser)
        {
            var user = _mapper.Map<User>(postUser);
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Users.Include(p => p.Gender).FirstOrDefaultAsync(q => q.Id == user.Id);
        }

        public async Task<User> GetUserAsync(UserFilter userFilter)
        {
            var queryable = _dataContext.Users.AsQueryable();
            queryable = AddFiltersOnQuery(userFilter, queryable);
            return await queryable.FirstOrDefaultAsync();
        }

        private static IQueryable<User> AddFiltersOnQuery(UserFilter filter, IQueryable<User> queryable)
        {
            if (!string.IsNullOrEmpty(filter.Email))
            {
                queryable = queryable.Where(p => p.Email == filter.Email);
            }
            if (!string.IsNullOrEmpty(filter.MobileNumber))
            {
                queryable = queryable.Where(p => p.MobileNumber == filter.MobileNumber);
            }

            return queryable;
        }
    }
}
