namespace PWF.Data.Mapper.Buddy
{
    using PWF.Model;
    using PWF.Resource.Request.Buddy;

    public static class BuddyModelMapper
    {
        public static Buddy MapToBuddyModel(this BuddyRequest request)
        {
            return new Buddy
            {
                MainUserId = request.MainUserId,
                BuddyUserId = request.BuddyUserId
            };
        }
    }
}
