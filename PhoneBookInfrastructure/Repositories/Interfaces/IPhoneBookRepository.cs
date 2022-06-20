using PhoneBookInfrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBookInfrastructure.Repositories.Interfaces
{
    public interface IPhoneBookRepository
    {
        Task<bool> AddAsync(Entry entry);
        Task<ICollection<PhoneBook>> GetAllAsync();
        Task<Entry> GetByIdAsync(int entryId);
        Task<bool> EntryExistsAsync(string phoneNumber);
        Task<bool> SaveAsync();
    }
}
