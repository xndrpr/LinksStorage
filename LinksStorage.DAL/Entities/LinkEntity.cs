using System.ComponentModel.DataAnnotations;

namespace LinksStorage.DAL.Entities
{
    public class LinkEntity : BaseEntity
    {
        [Required]
        public string Url { get; set; } = "example.com";
        [Required]
        public string Name { get; set; } = "Example";
        [Required]
        public string Icon { get; set; } = string.Empty;
    }
}
