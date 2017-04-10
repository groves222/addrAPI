using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AddrApi.Models;

namespace AddrApi.Controllers
{
    [Route("api/[controller]")]
    public class AddrController : Controller
    {
        private readonly IAddrRepository _addrRepository;

        public AddrController(IAddrRepository addrRepository)
        {
            _addrRepository = addrRepository;
        }

        [HttpGet]
        public IEnumerable<AddrItem> GetAll()
        {
            return _addrRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetAddr")]
        public IActionResult GetById(long id)
        {
            var item = _addrRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        [HttpPost]
        public IActionResult Create([FromBody] AddrItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _addrRepository.Add(item);

            return CreatedAtRoute("GetAddr", new { id = item.Key }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] AddrItem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var addr = _addrRepository.Find(id);
            if (addr == null)
            {
                return NotFound();
            }
            addr.EmailAddr = item.EmailAddr;
            addr.Addr = item.Addr;
            addr.Phone = item.Phone;
            addr.Name = item.Name;

            _addrRepository.Update(addr);
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var addr = _addrRepository.Find(id);
            if (addr == null)
            {
                return NotFound();
            }

            _addrRepository.Remove(id);
            return new NoContentResult();
        }
    }
}
