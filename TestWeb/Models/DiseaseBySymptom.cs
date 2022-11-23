using System.ComponentModel.DataAnnotations;

namespace TestWeb.Models
{
    public class DiseaseBySymptom
    {
        [Key]
        public int DiseaseBySymptomId { get; set; }

        public int SymptomId { get; set; }

        public int DiseaseId { get; set; }

        public virtual Symptom SymptomFromDiseaseBySymptom { get; set; }
        public virtual Disease DiseaseFromDiseaseBySymptom { get; set; }
    }
}
