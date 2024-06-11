namespace Management.Entity.Dto.Login
{
    public class LoginResponseDto : ResponseResultDto
    {
        public int Id { get; set; }
        public string? Company { get; set; }
        public string? Name { get; set; }
    }
}
