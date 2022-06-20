using Microsoft.EntityFrameworkCore;
using PhoneBookInfrastructure.Context;
using PhoneBookInfrastructure.Models;
using PhoneBookInfrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookInfrastructure.Repositories.Implementations
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly AppDbContext _context;
        public PhoneBookRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(Entry entry)
        {
            await _context.Entries.AddAsync(entry);
            return await SaveAsync();
        }

        public async Task<ICollection<PhoneBook>> GetAllAsync()
        {
            var allEntries = await _context.PhoneBooks.Include(x=>x.Entries).OrderBy(x => x.Name).ToListAsync();
            return allEntries;
        }

        public async Task<Entry> GetByIdAsync(int entryId)
        {
            Entry entry = await _context.Entries.FirstOrDefaultAsync(x => x.Id == entryId);
            return entry;
        }

        public async Task<bool> EntryExistsAsync(string phoneNumber)
        {
            bool result = await _context.Entries.AnyAsync(x => x.PhoneNumber == phoneNumber);
            return result;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
