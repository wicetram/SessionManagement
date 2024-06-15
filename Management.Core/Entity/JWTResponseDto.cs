namespace Management.Entity.Dto
{
    public class JWTResponseDto
    {
        public string Key { get; set; } = string.Empty;
        public string? Issuer { get; set; } = string.Empty;
        public string? Audience { get; set; } = string.Empty;
    }
}
