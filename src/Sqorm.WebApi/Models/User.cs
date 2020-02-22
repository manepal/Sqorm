using Sqorm.Data.Attributes;

namespace Sqorm.WebApi.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        [SqormDataField("is_deleted")]
        public bool IsDeleted { get; set; }
        
        [SqormDataField("date_created")]
        public System.DateTime CreatedAt { get; set; }
    } 
}