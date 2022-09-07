using System.ComponentModel.DataAnnotations;

namespace LinksStorage.DAL.Entities
{
    public class LinkEntity : BaseEntity
    {
        [Required]
        public UserEntity User { get; set; }
        [Required]
        public string Url { get; set; } = "example.com";
        [Required]
        public string Name { get; set; } = "Example";
    }
}
