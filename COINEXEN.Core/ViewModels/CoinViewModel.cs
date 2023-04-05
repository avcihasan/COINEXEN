namespace COINEXEN.Core.ViewModels
{
    public class CoinViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
        public string ShortName { get; set; }
        public int CategoryId { get; set; }
    }
}
