using HMS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMS.Areas.Dashboard.ViewModel
{
    public class AccomodationTypesListingModel
    {
        public IEnumerable<AccomodationType> AccomodationTypes { get; set; }
    }
    public class AccomodationTypeActionModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}