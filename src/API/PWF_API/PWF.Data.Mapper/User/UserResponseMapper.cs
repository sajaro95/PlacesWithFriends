namespace PWF.Data.Mapper.User
{
    using Model;
    using PWF.Resource.Response.Buddy;
    using PWF.Resource.Response.User;
    using System.Collections.Generic;

    public static class UserResponseMapper
    {
        public static UserResponse MapToUserResponse (this User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Buddies = user.MainUserBuddies.MapToBuddyResponse()
            };
        }

        public static IEnumerable<UserResponse> MapToUserResponse(this IEnumerable<User> users)
        {
            var responses = new List<UserResponse>();
            foreach (User user in users)
            {
                responses.Add(user.MapToUserResponse());
            }
            return responses;
        }

        #region Private Response Mappers
        private static IEnumerable<BuddyResponse> MapToBuddyResponse(this IEnumerable<Buddy> buddies)
        {
            if (buddies != null)
            {
                var responses = new List<BuddyResponse>();
                foreach (var buddy in buddies)
                {
                    responses.Add(new BuddyResponse
                    {
                        MainUserId = buddy.MainUserId,
                        BuddyUserId = buddy.BuddyUserId
                    });
                }
                return responses;
            }
            else return null;
        }
        #endregion
    }
}
