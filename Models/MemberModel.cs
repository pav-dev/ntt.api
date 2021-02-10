using System;
using System.Collections.Generic;

namespace ClaimsApi.Models
{
    public class MemberModel
    {
        public int MemberID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ClaimsModel> MemberClaims { get; set; }
    }
}