using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestWeb.Models
{
    public class Gender
    {
        [Key]
        public int GenderId { get; set; }

        public string Name { get; set; }

        public List<Client> Clients { get; set; }

        public List<Disease> Diseases { get; set; }
    }
}
