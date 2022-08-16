using System;
using System.ComponentModel.DataAnnotations;

namespace ReFeelRepository.DTO.User
{
    public class UserRegisterDTo
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        [Required, Phone]
        public string PhoneNumber { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
