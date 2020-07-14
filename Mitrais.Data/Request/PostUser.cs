using Mitrais.Data.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mitrais.Data.Request
{
    public class PostUser
    {
        [Required]
        [MobileNumberAttribute]
        public string MobileNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid? GenderId { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
