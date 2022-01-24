using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SuperTraders.Core.Entities
{
    public class Share: BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        
        [StringLength(3)]
        public string Code { get; set; }
        
        public ICollection<UserShare> UserShares { get; set; }

        public UserShare GetLowestPricedSellOrder()
        {
            // TODO: Will be implemented
            return new UserShare();
        }
    }
}