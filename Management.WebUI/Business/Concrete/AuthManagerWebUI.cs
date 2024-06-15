using Management.Business.Abstract;
using Management.Entity.Dto.Login;
using Management.Entity.Dto.Register;
using Management.WebUI.Business.Abstract;

namespace Management.WebUI.Business.Concrete
{
    public class AuthManagerWebUI(IAuthService auth) : IAuthServiceWebUI
    {
        private readonly IAuthService _auth = auth;

        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            return _auth.Login(loginRequestDto);
        }

        public Task<RegisterResponseDto> Register(RegisterRequestDto registerRequestDto)
        {
            return _auth.Register(registerRequestDto);
        }
    }
}
