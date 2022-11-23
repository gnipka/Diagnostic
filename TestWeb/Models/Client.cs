using System.ComponentModel.DataAnnotations;

namespace TestWeb.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int GenderId { get; set; }

        public virtual Gender ClientGender { get; set; }
    }
}
