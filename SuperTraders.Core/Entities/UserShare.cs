using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SuperTraders.Core.Entities
{
    public class UserShare: BaseEntity
    {
        public float Amount { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        
        public string ShareId { get; set; }
        public Share Share { get; set; }
    }
}