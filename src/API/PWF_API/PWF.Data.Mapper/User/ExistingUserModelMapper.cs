namespace PWF.Data.Mapper.User
{
    using PWF.Resource.Request.User;
    using PWF.Model;
    using System;

    public static class ExistingUserModelMapper
    {
        public static User MapExistingUserToModel(this UserRequest request)
        {
            return new User
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
        }
    }
}
