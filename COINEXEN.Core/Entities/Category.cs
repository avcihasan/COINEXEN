namespace COINEXEN.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Coin> Coins { get; set; }
    }
}
