using System.ComponentModel.DataAnnotations;

namespace IEQ2_BSIT32A1_Rollano.DTO.User
{
    public class CreateUserRequest
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public int Id { get; set; } 
    }
}
