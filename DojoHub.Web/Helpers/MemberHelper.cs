using System;
using DojoHub.Web.Models;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace DojoHub.Web.Helpers
{
    public class MemberHelper
    {
        private readonly IMemberService _memberService;

        public MemberHelper(IMemberService memberService)
        {
            _memberService = memberService;
        }
        
        public void Create(MemberCreationModel member)
        {
            // CreateWithIdentity(string username, string email, string password, string memberTypeAlias);
            _memberService.CreateMemberWithIdentity(member.Username, member.Email, member.DisplayName, member.MemberTypeAlias);
        }

        public Member Find()
        {
            throw new NotImplementedException();
        }
    }
}