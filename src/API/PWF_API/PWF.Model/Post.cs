namespace PWF.Model
{
    public class Post : BaseModel
    {
        public string Message { get; set; }
        public Location Location { get; set; }

        // Navigation Properties
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
