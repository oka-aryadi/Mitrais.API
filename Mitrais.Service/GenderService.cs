using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mitrais.Data;
using Mitrais.Data.Domain;
using Mitrais.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mitrais.Service
{
    public class GenderService : IGenderService
    {
        private IMapper _mapper;
        private DataContext _dataContext;

        public GenderService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Gender>> GetGendersAsync()
        {
            return await _dataContext.Genders.ToListAsync();
        }
    }
}
