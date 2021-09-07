using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3150RazorPages.Pages
{
    public class ValidationDAAModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        [Required]
        [StringLength(5, MinimumLength = 1)]
        public string InputField { get; set; }
        public void OnGet()
        {

        }
    }
}
