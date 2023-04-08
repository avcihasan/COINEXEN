namespace COINEXEN.Core.ViewModels
{
    public class CoinViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
        public int Stock { get; set; }
        public string ShortName { get; set; }
        public Guid CategoryId { get; set; }
    }
}
