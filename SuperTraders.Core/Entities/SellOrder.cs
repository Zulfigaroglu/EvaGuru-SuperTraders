namespace SuperTraders.Core.Entities
{
    public class SellOrder: BaseEntity
    {
        public float UnitPrice { get; set; }
        
        public int Amount { get; set; }
        
        public int RemainingAmount { get; set; }

        public bool IsTransactionPerformed { get; set; }
        
        public Transaction Transaction { get; set; }
        
        public string UserId { get; set; }
        public User User { get; set; }

        public string ShareId { get; set; }
        public Share Share { get; set; }
    }
}