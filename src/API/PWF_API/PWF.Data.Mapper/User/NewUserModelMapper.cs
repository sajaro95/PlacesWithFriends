namespace PWF.Data.Mapper.User
{
    using PWF.Model;
    using PWF.Resource.Request.User;

    public static class NewUserModelMapper
    {
        public static User MapNewUserToModel(this UserRequest request)
        {
            return new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
        }
    }
}
