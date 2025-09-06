using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiecastStore.Models.ViewModels
{
    public class ItemViewModel
    {
        public Item Item { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CarBrandList { get; set; }
    }
}
