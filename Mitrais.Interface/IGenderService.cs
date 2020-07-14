using Mitrais.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mitrais.Interface
{
    public interface IGenderService
    {
        Task<IEnumerable<Gender>> GetGendersAsync();
    }
}
