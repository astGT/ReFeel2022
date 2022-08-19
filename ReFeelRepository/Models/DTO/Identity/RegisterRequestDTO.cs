using System;
using System.ComponentModel.DataAnnotations;

namespace ReFeelRepository.Models.DTO.Identity
{
    public class RegisterRequestDTO
    {
        //[Required, Phone]
        //public string PhoneNumber { get; set; }
        //[Required, EmailAddress]
        //public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        //[Required, Phone, EmailAddress] add later
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }    
    }
}
