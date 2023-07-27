namespace SitecoreDiscover.GenerateProductFeed.Models
{
    public class ProductPriceBreak
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public object SalePrice { get; set; }
        public object SubscriptionPrice { get; set; }
    }
}