using Management.Entity.Dto.Login;
using Management.Entity.Dto.Register;

namespace Management.WebUI.Business.Abstract
{
    public interface IAuthServiceWebUI
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
    }
}
