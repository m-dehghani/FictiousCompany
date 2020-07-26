using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FictiousCompany.Foundational;
using FictiousCompany.Infrastructure;
using FictiousCompany.Infrastructure.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FictiousCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        protected IUnitOfWork UnitOfWork => _unitOfWork;
        public ApiBaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        [HttpHead]
        public int GetUserId()
        {
            var claims = User.Claims;
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            string userId = "";

            if (userIdClaim != null)
                userId = userIdClaim.Value;

            if (Int32.TryParse(userId, out int result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException(ResultType.InvalidUserToken.ToDescription());
            }
        }

       
        public int CurrentUserId => GetUserId();
    }
}