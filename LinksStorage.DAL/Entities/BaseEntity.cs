namespace LinksStorage.DAL.Entities
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public string CreationDate { get; set; } = DateTime.Now.ToShortDateString();
    }
}
