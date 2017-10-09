
namespace PWF.Model
{
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Buddy> Buddies { get; set; }
    }
}
