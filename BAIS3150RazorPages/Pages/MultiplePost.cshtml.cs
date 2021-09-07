using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3150RazorPages.Pages
{
    public class MultiplePostModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public string FirstInputField { get; set; }
        [BindProperty]
        public string SecondInputField { get; set; }
        [BindProperty] //Remember to add theses otherwise it will not track the names correctly and their values
        public string Submit { get; set; }
        public void OnGet()
        {
            Message = "*** On Get ***";
        }

        public void OnPost()
        {
            switch (Submit)
            {
                case "First":
                    Message = "First Input Field " + FirstInputField;
                    break;
                case "Second":
                    Message = "Second Input Field " + SecondInputField;
                    break;
            }
        }
    }
}
