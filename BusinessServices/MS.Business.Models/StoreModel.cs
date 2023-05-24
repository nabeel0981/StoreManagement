using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace MS.Business.Models
{
    public class StoreModel
    {
        public StoreModel() {
            Stores = new List<StoreModel> ();
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public ICollection<StoreModel> Stores { get; set; }
    }
}
