using System.Collections.Generic;

namespace PhoneBookCore.Dtos.Response
{
    public class PhoneBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EntryResponseDto> Entries { get; set; }
    }
}
