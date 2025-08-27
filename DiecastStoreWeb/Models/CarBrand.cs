using System.ComponentModel.DataAnnotations;

namespace DiecastStoreWeb.Models
{
    public class CarBrand
    {
        [Key]
        public int Id { get; set; }
        public string CarBrandName { get; set; }
        public int DisplayOrder { get; set; }
    }
}
