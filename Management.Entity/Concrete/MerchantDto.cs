using Management.Core.Entity;
using System.ComponentModel.DataAnnotations;

namespace Management.Entity.Concrete
{
    public class MerchantDto : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Company { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? CitizenNo { get; set; }
        public bool Status { get; set; }
    }
}
