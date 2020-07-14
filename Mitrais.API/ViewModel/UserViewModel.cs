using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mitrais.API.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Gender = new GenderViewModel();
        }

        public Guid Id { get; set; }
        public string MobileNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public GenderViewModel Gender { get; set; }
        public string Email { get; set; }
    }
}
