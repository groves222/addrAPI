using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddrApi.Models
{
    public class AddrItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Key { get; set; }
        public string Name { get; set; }
        public string Phone { get; set;}
        public string Addr { get; set; }
        public string EmailAddr { get; set; }
    }
}