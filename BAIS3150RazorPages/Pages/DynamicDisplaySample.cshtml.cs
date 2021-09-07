using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using BAIS3150RazorPages.Domain;

namespace BAIS3150RazorPages.Pages
{
    public class DynamicDisplaySampleModel : PageModel
    {
        private List<SampleClass> _sampleObjectCollection = new List<SampleClass>();
        public List<SampleClass> SampleObjectCollection
        {
            get
            {
                //By only putting get, it makes this read only
                return _sampleObjectCollection;
            }
        }

        public void OnGet()
        {
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
    }
}
