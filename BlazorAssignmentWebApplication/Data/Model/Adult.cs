using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAssignmentWebApplication.Data.Model
{
    [Table("Adults")]
    public class Adult : Person {
        
        
        public Adult(int id, string firstName, string lastName, string hairColor, string eyeColor, int age, float weight, int height, string sex, Job jobTitle) : base(id, firstName, lastName, hairColor, eyeColor, age, weight, height, sex)
        {
            JobTitle = jobTitle;
        }

        public Adult()
        { 
            JobTitle = new Job();
        }
        [ForeignKey("Job")]
        public Job JobTitle { get; set; }
        
        
    }
}