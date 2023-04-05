namespace COINEXEN.Core.Entities
{
    public class Coin : BaseEntity
    {

        public string Name { get; set; }
        public string KısaKod { get; set; }
        public string PhotoPath { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
