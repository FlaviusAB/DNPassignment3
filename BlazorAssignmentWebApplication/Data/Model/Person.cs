using System.ComponentModel.DataAnnotations;

namespace BlazorAssignmentWebApplication.Data.Model
{
    public class Person {
        public Person(int id, string firstName, string lastName, string hairColor, string eyeColor, int age, float weight, int height, string sex)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            HairColor = hairColor;
            EyeColor = eyeColor;
            Age = age;
            Weight = weight;
            Height = height;
            Sex = sex;
        }

        public Person()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            HairColor = string.Empty;
            EyeColor = string.Empty;
            Age = 0;
            Weight = 0;
            Height = 0;
            Sex = string.Empty;
        }

        [Key, MaxLength(7)]
        public int Id { get; set; }
        [Required, MaxLength(128)]
        public string FirstName { get; set; }
        [Required, MaxLength(128)]
        public string LastName { get; set; }
        [Required, MaxLength(128)]
        public string HairColor { get; set; }
        [Required, MaxLength(128)]
        public string EyeColor { get; set; }
        [Range (1,120, ErrorMessage = "Age not correct")]
        public int Age { get; set; }
        [Required]
        public float Weight { get; set; }
        [Required]
        public int Height { get; set; }
        [Required, MaxLength(1)]
        public string Sex { get; set; }
    }


}