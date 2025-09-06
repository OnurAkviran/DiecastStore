using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiecastStore.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(1, 100)]
        public double Price { get; set; }
        [DisplayName("Car Brand")]
        public int CarBrandId { get; set; }
        [ForeignKey("CarBrandId")]
        [ValidateNever]
        public CarBrand CarBrand { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
