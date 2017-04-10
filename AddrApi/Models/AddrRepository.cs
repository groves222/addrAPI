using System;
using System.Collections.Generic;
using System.Linq;

namespace AddrApi.Models
{
    public class AddrRepository : IAddrRepository
    {
        private readonly AddrContext _context;

        public AddrRepository(AddrContext context)
        {
            _context = context;

            if (_context.AddrItems.Count() == 0)
                Add(new AddrItem { Name = "Item1" });
        }

        public IEnumerable<AddrItem> GetAll()
        {
            return _context.AddrItems.ToList();
        }

        public void Add(AddrItem item)
        {
            _context.AddrItems.Add(item);
            _context.SaveChanges();
        }

        public AddrItem Find(long key)
        {
            return _context.AddrItems.FirstOrDefault(t => t.Key == key);
        }

        public void Remove(long key)
        {
            var entity = _context.AddrItems.First(t => t.Key == key);
            _context.AddrItems.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(AddrItem item)
        {
            _context.AddrItems.Update(item);
            _context.SaveChanges();
        }
    }
}
