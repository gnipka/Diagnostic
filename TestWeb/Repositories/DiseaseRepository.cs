using System.Collections.Generic;
using System.Linq;
using TestWeb.Models;

namespace TestWeb.Repositories
{
    public class DiseaseRepository : IRepository<Disease>
    {
        private readonly AppDbContext _AppDbContext;

        public DiseaseRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public void Create(Disease item)
        {
            _AppDbContext.Diseases.Add(item);
            _AppDbContext.SaveChanges();
        }

        public void Delete(Disease item)
        {
            _AppDbContext.Diseases.Remove(item);
            _AppDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var s = _AppDbContext.Diseases.ToList().Find(x => x.DiseaseId == id);
            _AppDbContext.Diseases.Remove(s);
            _AppDbContext.SaveChanges();
        }

        public Disease Get(int id)
        {
            return _AppDbContext.Diseases.ToList().Find(x => x.DiseaseId == id);
        }

        public List<Disease> GetAll()
        {
            return _AppDbContext.Diseases.ToList();
        }

        public void Update(Disease item)
        {
            var s = _AppDbContext.Diseases.ToList().Find(x => x.DiseaseId == item.DiseaseId);
            s.DiseaseGender = item.DiseaseGender;
            s.Lower_age_limit = item.Lower_age_limit;
            s.Upper_age_limit = item.Upper_age_limit;
            s.Name = item.Name;

            _AppDbContext.Diseases.Update(s);
            _AppDbContext.SaveChanges();
        }
    }
}
