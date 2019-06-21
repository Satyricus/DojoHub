using DojoHub.Web.Models;

namespace DojoHub.Web.Interfaces
{
    public interface IMemberHelper
    {
        bool Create(MemberCreationModel member);
    }
}