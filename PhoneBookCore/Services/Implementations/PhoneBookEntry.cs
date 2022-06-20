using AutoMapper;
using PhoneBookCore.Dtos.Request;
using PhoneBookCore.Dtos.Response;
using PhoneBookInfrastructure.Models;
using PhoneBookInfrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBookCore.Services.Implementations
{
    public class PhoneBookEntry : IPhoneBookEntry
    {
        private readonly IMapper _mapper;
        private readonly IPhoneBookRepository _phoneBookRepository;

        public PhoneBookEntry(IMapper mapper, IPhoneBookRepository phoneBookRepository)
        {
            _mapper = mapper;
            _phoneBookRepository = phoneBookRepository;
        }

        public async Task<EntryResponseDto> AddEntryToPhoneBookAsync(EntryRequestDto entryRequest)
        {
            Entry entry = _mapper.Map<Entry>(entryRequest);
            if (await _phoneBookRepository.EntryExistsAsync(entryRequest.PhoneNumber))
            {
                throw new ArgumentException("The entry you are trying to add already exits");
            }
            bool result = await _phoneBookRepository.AddAsync(entry);
            if (result)
            {
                return new EntryResponseDto()
                {
                    Id = entry.Id,
                    Name = entry.Name,
                    PhoneNumber = entry.PhoneNumber,
                    PhoneBookId = entry.PhoneBookId,
                };
            }
            throw new ArgumentException("Something went wrong. Try again.");
        }

        public async Task<List<PhoneBookDto>> GetAllPhoneBookEntriesAsync()
        {
            var allEntries = await _phoneBookRepository.GetAllAsync();
            var response = _mapper.Map<List<PhoneBookDto>>(allEntries);
            return response;
        }

        public async Task<EntryResponseDto> GetPhoneBookEntryByIdAsync(int entryId)
        {
            var entry = await _phoneBookRepository.GetByIdAsync(entryId);
            if (entry != null)
            {
                var result = _mapper.Map<EntryResponseDto>(entry);
                return result;
            }
            throw new ArgumentException("The entry does not exist");
        }
    }
}
