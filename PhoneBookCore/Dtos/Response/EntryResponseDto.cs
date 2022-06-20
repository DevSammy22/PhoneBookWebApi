namespace PhoneBookCore.Dtos.Response
{
    public class EntryResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneBookId { get; set; }
    }
}
