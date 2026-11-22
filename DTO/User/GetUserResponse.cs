
using System.Collections.Generic;

namespace IEQ2_BSIT32A1_Rollano.DTO.User
{
    public class GetUserResponse
    {
        public List<GetUserDTO> Users { get; set; }
            = new List<GetUserDTO>();
    }

    public class GetUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
