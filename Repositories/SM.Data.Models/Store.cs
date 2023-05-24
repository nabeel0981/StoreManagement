using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Data.Models
{
    public class Store : BaseEntity
    {
        public Store() {
            Stores = new HashSet<Store>();
        }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Store> Stores { get; set; }
    }
}
