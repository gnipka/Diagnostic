using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestWeb.Models
{
    public class Localization
    {
        [Key]
        public int LocalizationId { get; set; }

        public string Name { get; set; }

        public List<Symptom> Symptoms { get; set; }
    }
}
