using Management.Core.Entity;
using System.ComponentModel.DataAnnotations;

namespace Management.Entity.Dto.Login
{
    public class LoginRequestDto : IDto
    {
        [Required, DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
