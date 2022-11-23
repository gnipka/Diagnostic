using System.ComponentModel.DataAnnotations;

namespace TestWeb.Models
{
    public class Symptom
    {
        [Key]
        public int SymptomId { get; set; }

        public string Name { get; set; }

        public int LocalizationId { get; set; }

        public virtual Localization SymptomLocalization { get; set; }

    }
}