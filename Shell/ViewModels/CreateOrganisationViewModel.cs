using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shell.ViewModels
{
    public class CreateOrganisationViewModel
    {
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
    }
}