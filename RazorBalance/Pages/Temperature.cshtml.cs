using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorBalance.Pages
{
    public class TemperatureModel : PageModel
    {
        private readonly ILogger<TemperatureModel> _logger;
        private float temp;
        [BindProperty]
        public float TempConversion
        {
            get { return temp; }
            set { temp = value; }
        } 
        private int tempDrop;
        [BindProperty]
        public int TempDrop
        {
            get { return tempDrop; }
            set { tempDrop = value; }
        }
        public string Message { get; set; } = "F to C";
        public TemperatureModel(ILogger<TemperatureModel> logger)
        {

            _logger = logger;
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            DropCheck();
        } 
        public void FtoC() 
        {
            TempConversion = (TempConversion - 32) * 5 / 9;
        }
        public void CtoF()
        {
            TempConversion = (TempConversion * 9 / 5) + 32;
        }
        public void DropCheck()
        {
            if (TempDrop == 1)
            { 
                FtoC();
            }
            else {
                TempDrop = 2;
                CtoF();
                Message = "C to F";
            }
        }
    }
}
