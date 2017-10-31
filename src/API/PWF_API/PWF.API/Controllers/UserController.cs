namespace PWF.API.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using PWF.Resource.Response.User;
    using PWF.Resource.Request.User;
    using PWF.Data.Mapper.User;
    using PWF.Data.UnitOfWork;
    using PWF.Model;
    using System.Net.Http;
    using System.Net;

    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<UserResponse> Get()
        {
            return _unitOfWork.UserRepository.Get().MapToUserResponse();
        }
        
        [HttpGet("{id}")]
        public UserResponse Get(int id)
        {
            return _unitOfWork.UserRepository.Get(id).MapToUserResponse();
        }
        
        [HttpPost]
        public HttpResponseMessage Create(UserRequest request)
        {
            _unitOfWork.UserRepository.Insert(request.MapNewUserToModel());
            _unitOfWork.Save();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        
        [HttpPut("{id}")]
        public HttpResponseMessage Update(UserRequest request)
        {
            _unitOfWork.UserRepository.Update(request.MapExistingUserToModel());
            _unitOfWork.Save();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            User user = _unitOfWork.UserRepository.GetById(id);
            _unitOfWork.UserRepository.Delete(id);
            _unitOfWork.Save();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
