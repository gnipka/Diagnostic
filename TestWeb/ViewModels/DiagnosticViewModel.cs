using System.Collections.Generic;
using TestWeb.Models;

namespace TestWeb.ViewModels
{
    public class DiagnosticViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Symptom[] Symptoms { get; set; }
        public string Disease { get; set; }
        public string Gender { get; set; }
    }
}
