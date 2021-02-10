using ClaimsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClaimsApi.ClaimsServices
{
    public interface IClaimServices
    {
        List<MemberModel> GetMemClaimsByDate(DateTime byClaimDate);
    }
}