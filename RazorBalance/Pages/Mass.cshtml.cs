using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorBalance.Pages
{
    public class MassModel : PageModel
    {
        private readonly ILogger<MassModel> _logger;
        
        
        private float massconversion;
        [BindProperty]
        public float MassConversion
        {
            get { return massconversion; }
            set { massconversion = value; }
        }

        
        private int massDrop;
        [BindProperty]
        public int MassDrop
        {
            get { return massDrop; }
            set { massDrop = value; }
        }

        public string Message { get; set; } = "Lb to Oz";

        public MassModel(ILogger<MassModel> logger)
        {
            _logger = logger;
        }

        public void OnPost()
        {
            DropCheck();
        }
        public void OnGet()
        {  
        }
        public void DropCheck()
        {
            if (MassDrop == 1)
            {
                LbToOz();
            }
            if (MassDrop == 2)
            {
                OzToLb();
                Message = "Oz to Lb";
            }
            if (MassDrop == 3)
            {
                GrToLb();
                Message = "G to Lb";
            }
            if (MassDrop == 4) 
            {
                MgToLb();
                Message = "Mg to Lb";
            }
        }
        public void LbToOz() 
        {
            MassConversion = MassConversion * 16;
        }
        public void OzToLb()
        {
            MassConversion = MassConversion / 16;
        }

        public void GrToLb()
        {
            MassConversion = MassConversion / 454;
        }

        public void MgToLb()
        {
            MassConversion = MassConversion / 453592;
        }
    }
}
