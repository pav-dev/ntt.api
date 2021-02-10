using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using ClaimsApi.Models;

namespace ClaimsApi.ClaimsServices
{
    public class ClaimServices:IClaimServices 
    {
        public List<MemberModel> GetMemClaimsByDate(DateTime byClaimDate)
        {
            CsvDataLoader csvDtLdr = new CsvDataLoader(); //Not implementing interface
                List<MemberModel> members = csvDtLdr.GetMembersFromCsv();
                List<ClaimsModel> memberClaims = csvDtLdr.GetClaimsFromCsv();
            
            foreach (MemberModel member in members)
                member.MemberClaims = memberClaims.FindAll(p => p.MemberID == member.MemberID
                                                        && p.ClaimDate.Date <= byClaimDate.Date);

            return members.Where(p=>p.MemberClaims.Count>0).ToList();

        }

    }
}