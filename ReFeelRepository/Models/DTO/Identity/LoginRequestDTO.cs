using System;
using System.ComponentModel.DataAnnotations;

namespace ReFeelRepository.Models.DTO.Identity
{
    public class LoginRequestDTO
    {
        public string Username { get; set; } //this will be either phoneNo or emailAddres
        public string Password { get; set; }
        //[Required, Phone, EmailAddress] add later        
    }
}
