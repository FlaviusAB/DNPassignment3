using BlazorAssignmentWebApplication.Data.Model;

namespace BlazorAssignmentWebApplication.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password); 
    }
}