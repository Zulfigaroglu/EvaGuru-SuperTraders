using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SuperTraders.Core.Entities
{
    public class User: BaseEntity
    {
        public string AuthToken { get; set; } = "";

        [MaxLength(50)]
        public string UserName { get; set; }
        
        [MaxLength(32)]
        [JsonIgnore]
        public string Password { get; set; }
        
        public string EMail { get; set; }
        
        [DefaultValue(false)]
        public bool IsEMailVerified { get; set; }
        
        public float Balance { get; set; }
        
        public ICollection<UserShare> UserShares { get; set; }
    }
}