using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SuperTraders.Core.Entities
{
    public class Share: BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        
        [StringLength(3)]
        public string Code { get; set; }
        
        public ICollection<UserShare> UserShares { get; set; }
        
        public ICollection<SellOrder> SellOrders { get; set; }
        
        public ICollection<BuyOrder> BuyOrders { get; set; }
        
        public float Price
        {
            get => GetLowestPricedSellOrder()!.UnitPrice;
        }

        public SellOrder? GetLowestPricedSellOrder()
        {
            return SellOrders.OrderBy(so => so.UnitPrice).FirstOrDefault();
        }
    }
}