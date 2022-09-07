using LinksStorage.DAL.Entities;

namespace LinksStorage.Domain.Models
{
    public class LinkModel
    {
        public UserEntity User { get; set; } = new UserEntity();
        public string Url { get; set; } = "example.com";
        public string Name { get; set; } = "Example";
    }
}
