using Management.Entity.Dto;
using Management.Entity.Dto.Login;
using Management.Entity.Dto.Register;

namespace Management.Business.Abstract
{
    public interface IAuthService
    {
        /// <summary>
        /// Kullanıcı kayıt işlemi
        /// </summary>
        /// <param name="registerRequestDto"></param>
        /// <returns></returns>
        Task<RegisterResponseDto> Register(RegisterRequestDto registerRequestDto);

        /// <summary>
        /// Kullanıcı giriş işlemi
        /// </summary>
        /// <param name="loginRequestDto"></param>
        /// <returns></returns>
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

        /// <summary>
        /// Kayitlı kullanıcı kontrolü
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<ResponseResultDto> UserExists(string email);
    }
}
