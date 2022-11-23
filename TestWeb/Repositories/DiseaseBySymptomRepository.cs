using System.Collections.Generic;
using System.Linq;
using TestWeb.Models;

namespace TestWeb.Repositories
{
    public class DiseaseBySymptomRepository : IRepository<DiseaseBySymptom>
    {
        private readonly AppDbContext _AppDbContext;

        public DiseaseBySymptomRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public void Create(DiseaseBySymptom item)
        {
            _AppDbContext.DiseaseBySymptoms.Add(item);
            _AppDbContext.SaveChanges();
        }

        public void Delete(DiseaseBySymptom item)
        {
            _AppDbContext.DiseaseBySymptoms.Remove(item);
            _AppDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var s = _AppDbContext.DiseaseBySymptoms.ToList().Find(x => x.DiseaseBySymptomId == id);
            _AppDbContext.DiseaseBySymptoms.Remove(s);
            _AppDbContext.SaveChanges();
        }

        public DiseaseBySymptom Get(int id)
        {
            return _AppDbContext.DiseaseBySymptoms.ToList().Find(x => x.DiseaseBySymptomId == id);
        }

        public List<DiseaseBySymptom> GetAll()
        {
            return _AppDbContext.DiseaseBySymptoms.ToList();
        }

        public void Update(DiseaseBySymptom item)
        {
            var s = _AppDbContext.DiseaseBySymptoms.ToList().Find(x => x.DiseaseBySymptomId == item.DiseaseBySymptomId);
            s.DiseaseId = item.DiseaseId;
            s.SymptomId = item.SymptomId;

            _AppDbContext.DiseaseBySymptoms.Update(s);
            _AppDbContext.SaveChanges();
        }
    }
}
