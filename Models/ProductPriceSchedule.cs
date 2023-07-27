using System.Collections.Generic;

namespace SitecoreDiscover.GenerateProductFeed.Models
{
    public class ProductPriceSchedule
    {
        public string OwnerID { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public bool ApplyTax { get; set; }
        public bool ApplyShipping { get; set; }
        public int MinQuantity { get; set; }
        public object MaxQuantity { get; set; }
        public bool UseCumulativeQuantity { get; set; }
        public bool RestrictedQuantity { get; set; }
        public List<ProductPriceBreak> PriceBreaks { get; set; }
        public object Currency { get; set; }
        public object SaleStart { get; set; }
        public object SaleEnd { get; set; }
        public bool IsOnSale { get; set; }
        public object xp { get; set; }
    }
}
