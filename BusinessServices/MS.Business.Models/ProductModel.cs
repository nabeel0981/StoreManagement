using System.ComponentModel.DataAnnotations.Schema;

namespace MS.Business.Models
{
    public class ProductModel
    {
        public ProductModel() {
         store = new StoreModel();
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int StoreId { get; set; }
        
        public StoreModel store { get; set; }

    }
}