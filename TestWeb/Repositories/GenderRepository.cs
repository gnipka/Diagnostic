using System.Collections.Generic;
using System.Linq;
using TestWeb.Models;

namespace TestWeb.Repositories
{
    public class GenderRepository : IRepository<Gender>
    {
        private readonly AppDbContext _AppDbContext;

        public GenderRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public void Create(Gender item)
        {
            _AppDbContext.Genders.Add(item);
            _AppDbContext.SaveChanges();
        }

        public void Delete(Gender item)
        {
            _AppDbContext.Genders.Remove(item);
            _AppDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var s = _AppDbContext.Genders.ToList().Find(x => x.GenderId == id);
            _AppDbContext.Genders.Remove(s);
            _AppDbContext.SaveChanges();
        }

        public Gender Get(int id)
        {
            return _AppDbContext.Genders.ToList().Find(x => x.GenderId == id);
        }

        public List<Gender> GetAll()
        {
            return _AppDbContext.Genders.ToList();
        }

        public void Update(Gender item)
        {
            var s = _AppDbContext.Genders.ToList().Find(x => x.GenderId == item.GenderId);
            s.Name = item.Name;

            _AppDbContext.Genders.Update(s);
            _AppDbContext.SaveChanges();
        }
    }
}
