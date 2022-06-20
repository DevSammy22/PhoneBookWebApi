using System.ComponentModel.DataAnnotations;

namespace PhoneBookInfrastructure.Models
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public int PhoneBookId { get; set; }
    }
}
