using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3150RazorPages.Pages
{
    public class TestPageModel : PageModel
    {
        public string Message { get; set; }
        public string Field { get; set; }
        public void OnGet()
        {
            Message = "*** OnGet ***";
        }
        public void OnPost()
        {
            Message = "*** On Post ***";
        }
    }
}
