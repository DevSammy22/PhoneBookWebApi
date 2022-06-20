using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookCore.Dtos.Request;
using PhoneBookCore.Services.Implementations;
using System;
using System.Threading.Tasks;

namespace PhoneBookApi.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class PhoneBookEntryController : ControllerBase
    {

        private readonly IPhoneBookEntry _phoneBookEntry;
        public PhoneBookEntryController(IPhoneBookEntry phoneBookEntry)
        {
            _phoneBookEntry = phoneBookEntry;
        }
        
        [HttpPost]
        [Route("AddEntry")]
        public async Task<IActionResult> AddEntryAsync([FromBody] EntryRequestDto entryRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _phoneBookEntry.AddEntryToPhoneBookAsync(entryRequest);
                return Created("", result);
            }
            catch(ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetAllEntries")]
        public async Task<IActionResult> GetAllEntriesAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _phoneBookEntry.GetAllPhoneBookEntriesAsync();
                return Ok(result);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetEntryById")]
        public async Task<IActionResult> GetEntryByIdAsync(int entryId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _phoneBookEntry.GetPhoneBookEntryByIdAsync(entryId);
                return Ok(result);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
