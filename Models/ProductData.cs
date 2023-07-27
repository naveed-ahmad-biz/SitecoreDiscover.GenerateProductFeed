namespace SitecoreDiscover.GenerateProductFeed.Models
{
    public class ProductData
    {
        

        public ProductPriceSchedule PriceSchedule { get; set; }
        public string OwnerID { get; set; }
        public string DefaultPriceScheduleID { get; set; }
        public bool AutoForward { get; set; }
        public string ID { get; set; }
        public object ParentID { get; set; }
        public bool IsParent { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int QuantityMultiplier { get; set; }
        public object ShipWeight { get; set; }
        public object ShipHeight { get; set; }
        public object ShipWidth { get; set; }
        public object ShipLength { get; set; }
        public bool Active { get; set; }
        public int SpecCount { get; set; }
        public int VariantCount { get; set; }
        public string ShipFromAddressID { get; set; }
        public object Inventory { get; set; }
        public object DefaultSupplierID { get; set; }
        public bool AllSuppliersCanSell { get; set; }
        public bool Returnable { get; set; }
        public ProductDataXP XP { get; set; }
    }
}
