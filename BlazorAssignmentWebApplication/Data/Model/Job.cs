using System.ComponentModel.DataAnnotations;

namespace BlazorAssignmentWebApplication.Data.Model
{
    
    public class Job
    {
        [Key, MaxLength(7)]
        public int Id { get; set; }
        public Adult JobTitle { get; set; }
        [Required]
        public int Salary { get; set; }
    }
}