using System.Collections.Generic;

namespace LoginExample.Data.Model
{
    public class Child : Person {
    
        public List<Interest> Interests { get; set; }
        public List<Pet> Pets { get; set; }
    }
}