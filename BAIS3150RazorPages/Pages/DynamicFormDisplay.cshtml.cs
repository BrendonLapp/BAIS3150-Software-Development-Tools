using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAIS3150RazorPages.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3150RazorPages.Pages
{
    public class DynamicFormDisplayModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public string AField { get; set; }
        [BindProperty]
        public string ACollection { get; set; }
        public List<SampleClass> SampleObjectCollection { get; } = new List<SampleClass>();
        public void OnGet()
        {
            Message = "OnGet";

            SampleClass SampleObject;

            SampleObject = new SampleClass
            {
                FirstProperty = "1",
                SecondProperty = "one"
            };
            SampleObjectCollection.Add(SampleObject);

            SampleObject = new SampleClass
            {
                FirstProperty = "2",
                SecondProperty = "two"
            };
            SampleObjectCollection.Add(SampleObject);

            SampleObject = new SampleClass
            {
                FirstProperty = "3",
                SecondProperty = "three"
            };
            SampleObjectCollection.Add(SampleObject);

        }

        public void OnPost()
        {
            Message = "On Post";


        }
    }
}
