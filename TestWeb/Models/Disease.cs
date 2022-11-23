using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestWeb.Models
{
    public class Disease
    {
        [Key]
        public int DiseaseId { get; set; }

        public string Name { get; set; }

        public int Lower_age_limit { get; set; }

        public int Upper_age_limit { get; set; }

        public int GenderId { get; set; }

        public virtual Gender DiseaseGender { get; set; }

        public List<DiseaseBySymptom> DiseaseBySymptoms { get; set; }
    }
}
