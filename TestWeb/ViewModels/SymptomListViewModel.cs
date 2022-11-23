using System.Collections.Generic;
using TestWeb.Models;

namespace TestWeb.ViewModels
{
    public class LocalizationListViewModel
    {
        public IEnumerable<Localization> AllLocalizations { get; set; }
        public IEnumerable<Symptom> AllSymptoms { get; set; }        
    }
}
