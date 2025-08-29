using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DiecastStore.Models
{
    public class CarBrand
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Brand Name")]
        public string CarBrandName { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100)]
        public int DisplayOrder { get; set; }
    }
}
