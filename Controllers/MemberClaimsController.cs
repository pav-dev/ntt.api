using ClaimsApi.ClaimsServices;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ClaimsApi.Controllers
{
    [RoutePrefix(RouteUtils.RtPrefix)]
    public class MemberClaimsController : ApiController
    {
        private IClaimServices _claimServices;

        [HttpGet, Route(RouteUtils.RtMemClaims)]
        public IHttpActionResult GetMemClaimsByDate(DateTime byClaimDate)
        {
            try
            {
                _claimServices = new ClaimServices();
                var p = _claimServices.GetMemClaimsByDate(byClaimDate)
                        .Select(x => new { MemberName = x.FirstName + ", " + x.LastName, x.MemberClaims });

                if (p != null && p.Any())
                    return Ok(p);
                else
                    return Content(HttpStatusCode.NotFound, "Your Claim date doesn't return any member cliams.");
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
                //log exception here
            }

        }


    }
}
