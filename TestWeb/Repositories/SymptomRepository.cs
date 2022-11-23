using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestWeb.Models;

namespace TestWeb.Repositories
{
    public class SymptomRepository : IRepository<Symptom>
    {
        private readonly AppDbContext _AppDbContext;

        public SymptomRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public void Create(Symptom item)
        {
            _AppDbContext.Symptoms.Add(item);
            _AppDbContext.SaveChanges();
        }

        public void Delete(Symptom item)
        {
            _AppDbContext.Symptoms.Remove(item);
            _AppDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var s = _AppDbContext.Symptoms.ToList().Find(x => x.SymptomId == id);
            _AppDbContext.Symptoms.Remove(s);
            _AppDbContext.SaveChanges();
        }

        public Symptom Get(int id)
        {
            return _AppDbContext.Symptoms.ToList().Find(x => x.SymptomId == id);
        }

        public List<Symptom> GetAll()
        {
            return _AppDbContext.Symptoms.ToList();
        }

        public void Update(Symptom item)
        {
            var s = _AppDbContext.Symptoms.ToList().Find(x => x.SymptomId == item.SymptomId);
            s.Name = item.Name;
            s.SymptomId = item.SymptomId;
            s.SymptomLocalization = item.SymptomLocalization;

            _AppDbContext.Symptoms.Update(s);
            _AppDbContext.SaveChanges();
        }
    }
}
