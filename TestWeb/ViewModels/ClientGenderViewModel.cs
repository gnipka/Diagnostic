using System.Collections.Generic;
using TestWeb.Models;
using TestWeb.Repositories;

namespace TestWeb.ViewModels
{
    public class ClientGenderViewModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int GenderId { get; set; }

        public IEnumerable<Gender> AllGenders { get; set; }
    }
}
