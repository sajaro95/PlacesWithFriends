namespace PWF.API.Controllers
{
    using PWF.Resource.Response.Buddy;
    using PWF.Resource.Request.Buddy;
    using PWF.Data.Mapper.Buddy;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using PWF.Data.UnitOfWork;
    using System.Net.Http;
    using System.Net;
    using PWF.Model;

    [Produces("application/json")]
    [Route("api/Buddy")]
    public class BuddyController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public BuddyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<BuddyResponse> Get()
        {
            return _unitOfWork.BuddyRepository.Get().MapToBuddyResponse();
        }

        [HttpGet("mainUserId/{mainUserId}")]
        public IEnumerable<BuddyResponse> Get(int mainUserId)
        {
            return _unitOfWork.BuddyRepository.GetByMainUserId(mainUserId).MapToBuddyResponse();
        }

        [HttpPost]
        public HttpResponseMessage Create(BuddyRequest request)
        {
            _unitOfWork.BuddyRepository.Insert(request.MapToBuddyModel());
            _unitOfWork.Save();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete("mainUserId/{mainUserId}/buddyUserId/{buddyUserId}")]
        public HttpResponseMessage Delete(int mainUserId, int buddyUserId)
        {
            _unitOfWork.BuddyRepository.Delete(mainUserId, buddyUserId);
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
