namespace SuperTraders.Core.Entities
{
    public class UserShare : BaseEntity
    {
        public int Amount { get; set; }
        
        public string UserId { get; set; }
        public User User { get; set; }

        public string ShareId { get; set; }
        public Share Share { get; set; }
    }
}