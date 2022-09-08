namespace LinksStorage.DAL.Entities
{
    public interface IEntity
    {
        public int Id { get; set; }
        public string CreationDate { get; set; }
    }
}
