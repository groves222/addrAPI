using System.Collections.Generic;

namespace AddrApi.Models
{
    public interface IAddrRepository
    {
        void Add(AddrItem item);
        IEnumerable<AddrItem> GetAll();
        AddrItem Find(long key);
        void Remove(long key);
        void Update(AddrItem item);
    }
}
