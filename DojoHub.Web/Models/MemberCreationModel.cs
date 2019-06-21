namespace DojoHub.Web.Models
{
    public class MemberCreationModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string MemberTypeAlias { get; set; }
    }
}