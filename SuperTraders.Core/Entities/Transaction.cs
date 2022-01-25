namespace SuperTraders.Core.Entities
{
    public class Transaction: BaseEntity
    {
        public float Amount { get; set; }
        public string SellOrderId { get; set; }
        public SellOrder SellOrder { get; set; }

        public string BuyOrderId { get; set; }
        public BuyOrder BuyOrder { get; set; }
    }
}