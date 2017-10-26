namespace PWF.Model
{
    public class Location : BaseModel
    {
        public string LocationName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }

        // Navigation Properties
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
