using Management.Core.Entity;

namespace Management.Entity.Dto
{
    public class ResponseResultDto : IDto
    {
        public bool Result { get; set; }
        public string ResultMessage { get; set; } = string.Empty;
    }
}
