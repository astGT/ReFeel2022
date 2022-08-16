using System;
using System.ComponentModel.DataAnnotations;

namespace ReFeelRepository.DTO.User
{
    public class UserLoginDTo
    {
        public string FirstName { get; set; }     
        public string LastName { get; set; }

        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
