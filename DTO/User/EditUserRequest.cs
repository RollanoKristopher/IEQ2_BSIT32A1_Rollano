using System.ComponentModel.DataAnnotations;

namespace IEQ2_BSIT32A1_Rollano.DTO.User
{
    public class EditUserRequest
    {

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Id { get; set; }
    }
}
