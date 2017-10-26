namespace PWF.Data.Mapper.User
{
    using Model;
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
                Email = user.Email
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
    }
}
