namespace PWF.Data.Mapper.Buddy
{
    using PWF.Resource.Response.Buddy;
    using PWF.Resource.Response.User;
    using System.Collections.Generic;
    using PWF.Model;

    public static class BuddyResponseMapper
    {
        public static BuddyResponse MapToBuddyResponse(this Buddy buddy)
        {
            return new BuddyResponse
            {
                BuddyUser = buddy.BuddyUser.MapToUserResponse(),
                MainUser = buddy.MainUser.MapToUserResponse(),
                BuddyUserId = buddy.BuddyUserId,
                MainUserId = buddy.MainUserId
            };
        }

        public static IEnumerable<BuddyResponse> MapToBuddyResponse(this IEnumerable<Buddy> buddies)
        {
            var responses = new List<BuddyResponse>();
            foreach (var buddy in buddies)
            {
                responses.Add(buddy.MapToBuddyResponse());
            }
            return responses;
        }

        #region Private Response Mappers
        private static UserResponse MapToUserResponse(this User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }
        #endregion
    }
}
