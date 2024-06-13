using Management.Business.Abstract;
using Management.DataAccess.Abstract;
using Management.Entity.Concrete;
using Management.Entity.Dto;
using Management.Entity.Dto.Login;
using Management.Entity.Dto.Register;

namespace Management.Business.Concrete
{
    public class AuthManager(IMerchantDal merchant) : IAuthService
    {
        private readonly IMerchantDal _merchant = merchant;

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var response = await _merchant.GetAsync(x => x.Email == loginRequestDto.Email);

            if (response == null)
            {
                return new LoginResponseDto
                {
                    Result = false,
                    ResultMessage = "Kullanıcı hesabı bulunamadı. Üye olmayı deneyebilirsin"
                };
            }

            if (!response.Status)
            {
                return new LoginResponseDto
                {
                    Result = false,
                    ResultMessage = "Kullanıcı pasif durumdadır. Lütfen bloke kaldırma işlemi yapınız"
                };
            }

            if (response.Password != loginRequestDto.Password)
            {
                return new LoginResponseDto
                {
                    Result = false,
                    ResultMessage = "Parola hatalı veya kullanıcı mevcut değil"
                };
            }

            return new LoginResponseDto
            {
                Result = true,
                ResultMessage = "Giriş başarılı",
                Id = response.Id,
                Company = response.Company,
                Name = response.Name
            };
        }

        public async Task<RegisterResponseDto> Register(RegisterRequestDto registerRequestDto)
        {
            var check = await UserExists(registerRequestDto.Email);

            if (check.Result)
            {
                var merchant = CreateMerchant(registerRequestDto);

                var response = await _merchant.AddAsync(merchant);

                if (response == 0)
                {
                    return new RegisterResponseDto
                    {
                        Result = false,
                        ResultMessage = "Kullanıcı kayıt işlemi başarısız. Lütfen tekrar deneyiniz"
                    };
                }

                return new RegisterResponseDto
                {
                    Id = response,
                    Result = true,
                    ResultMessage = "Kayıt işlemi başarılı"
                };
            }

            return new RegisterResponseDto
            {
                Result = check.Result,
                ResultMessage = check.ResultMessage,
            };
        }

        public async Task<ResponseResultDto> UserExists(string email)
        {
            var response = await _merchant.GetAsync(x => x.Email == email);

            if (response != null)
            {
                return new ResponseResultDto
                {
                    Result = false,
                    ResultMessage = "Aynı E-Posta ile kullanıcı mevcut, aynı E-Posta ile tekrar kayıt olamaz"
                };
            }

            return new ResponseResultDto
            {
                Result = true,
                ResultMessage = "Eşleşen bir kayıt yok, kayıt olabilir"
            };

        }

        /// <summary>
        /// Database için kayıt oluşturur
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        private static Merchant CreateMerchant(RegisterRequestDto register) => new()
        {
            Name = register.Name,
            Surname = register.Surname,
            Email = register.Email,
            Password = register.Password,
            Phone = register.Phone,
            CitizenNo = register.CitizenNo,
            Company = $"{register.Name} {register.Surname}",
            Status = true
        };
    }
}
