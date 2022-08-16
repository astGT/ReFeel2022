using System.ComponentModel.DataAnnotations;

namespace ReFeelRepository.Models.DTo.Entities
{
    public  class UserDTo
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Password { get; set; }        
        public string ImageUrl { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
