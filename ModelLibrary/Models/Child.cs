using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelLibrary.Models
{
    public class Child
    {
        [Key, MaxLength(50)]
        public string Name { get; set; }
        [Required, Range(3,6)]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        public List<Toy> Toys { get; set; }
    }
}