using PhoneBookCore.Dtos.Request;
using PhoneBookCore.Dtos.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBookCore.Services.Implementations
{
    public interface IPhoneBookEntry
    {
        Task<EntryResponseDto> AddEntryToPhoneBookAsync(EntryRequestDto entryRequest);
        Task<List<PhoneBookDto>> GetAllPhoneBookEntriesAsync();
        Task<EntryResponseDto> GetPhoneBookEntryByIdAsync(int entryId);
    }
}