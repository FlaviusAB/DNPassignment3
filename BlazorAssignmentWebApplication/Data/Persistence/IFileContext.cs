using System.Collections.Generic;
using BlazorAssignmentWebApplication.Data.Model;


namespace BlazorAssignmentWebApplication.Data.Persistence
{
    public interface IFileContext
    {
        IList<Adult> Adults { get; }
        //IList<Family> Families { get; }

        void SaveChanges();
    }
}