namespace PWF.Resource.Response.Buddy
{
    using PWF.Resource.Response.User;

    public class BuddyResponse
    {
        public int BuddyUserId { get; set; }
        public int MainUserId { get; set; }

        public UserResponse BuddyUser { get; set; }
        public UserResponse MainUser { get; set; }
    }
}
