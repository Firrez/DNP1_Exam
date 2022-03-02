using System.ComponentModel.DataAnnotations;

namespace ModelLibrary.Models
{
    public class Toy
    {
        [Key, MaxLength(20)]
        public string Name { get; set; }
        public string Color { get; set; }
        public string Condition { get; set; }
        public bool IsFavourite { get; set; }
    }
}