namespace PWF.Resource.Response.User
{
    using PWF.Resource.Response.Buddy;
    using PWF.Resource.Response.Post;
    using System.Collections.Generic;

    public class UserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<PostResponse> Posts { get; set; }
        public IEnumerable<BuddyResponse> Buddies { get; set; }
    }
}
