namespace LinksStorage.Domain.Models
{
    public class UserModel
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public bool IsVerified { get; set; } = false;
        public IEnumerable<LinkModel> Links { get; set; } = Enumerable.Empty<LinkModel>();
    }
}
