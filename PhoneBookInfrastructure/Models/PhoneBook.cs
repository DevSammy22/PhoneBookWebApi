using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookInfrastructure.Models
{
    public class PhoneBook
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Entry> Entries { get; set; }
    }
}
