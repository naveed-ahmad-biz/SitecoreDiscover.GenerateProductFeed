using System.Collections.Generic;

namespace SitecoreDiscover.GenerateProductFeed.Models
{
    public class ProductDataXP
    {
        public List<ProductDataXPImage> Images { get; set; }
        public string Status { get; set; }
        public ProductDataXPUnitOfMeasure UnitOfMeasure { get; set; }
        public string ProductType { get; set; }
        public string Currency { get; set; }
        public string Brand { get; set; }
        public string ProductUrl { get; set; }
        public string CCID { get; set; }
    }
}
