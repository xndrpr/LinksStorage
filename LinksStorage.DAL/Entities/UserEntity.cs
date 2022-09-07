using System.ComponentModel.DataAnnotations;

namespace LinksStorage.DAL.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public bool IsVerified { get; set; } = false;
        public ICollection<LinkEntity>? Links { get; set; } = null;
    }
}
