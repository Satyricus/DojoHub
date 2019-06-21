using System;
using DojoHub.Web.Interfaces;
using DojoHub.Web.Models;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace DojoHub.Web.Helpers
{
    public class MemberHelper : IMemberHelper
    {
        private readonly IMemberService _memberService;

        public MemberHelper(IMemberService memberService)
        {
            _memberService = memberService;
        }
        
        public bool Create(MemberCreationModel member)
        {
            // CreateWithIdentity(string username, string email, string password, string memberTypeAlias);
            _memberService.CreateMemberWithIdentity(member.Username, member.Email, member.DisplayName, member.MemberTypeAlias);
            return true;
        }

        public Member Find()
        {
            throw new NotImplementedException();
        }
    }
}