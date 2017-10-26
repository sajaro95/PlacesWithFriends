namespace PWF.Model
{
    using System.Collections.Generic;

    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        
        public virtual ICollection<Buddy> Buddies { get; set; }
        public virtual ICollection<Buddy> MainUserBuddies { get; set; }
    }
}
