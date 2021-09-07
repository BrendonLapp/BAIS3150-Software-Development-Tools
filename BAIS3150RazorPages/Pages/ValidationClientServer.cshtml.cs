using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3150RazorPages.Pages
{
    public class ValidationClientServerModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public string InputField { get; set; }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            if (InputField == null || !(InputField.Length > 0 && InputField.Length <= 5))
            {
                ModelState.AddModelError("InputField", "Input field is required and must be up to 5 characters");
            }
            if (ModelState.IsValid)
            {
                Message = "On Post - Is Valid";
            }
            else
            {
                Message = "On Post - Is Not Valid";
            }

        }
    }
}
