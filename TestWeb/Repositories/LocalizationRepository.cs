using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestWeb.Models;

namespace TestWeb.Repositories
{
    public class LocalizationRepository : IRepository<Localization>
    {

        private readonly AppDbContext _AppDbContext;

        public LocalizationRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public void Create(Localization item)
        {
            _AppDbContext.Localizations.Add(item);
            _AppDbContext.SaveChanges();
        }

        public void Delete(Localization item)
        {
            _AppDbContext.Localizations.Remove(item);
            _AppDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var s = _AppDbContext.Localizations.ToList().Find(x => x.LocalizationId == id);
            _AppDbContext.Localizations.Remove(s);
            _AppDbContext.SaveChanges();
        }

        public Localization Get(int id)
        {
            return _AppDbContext.Localizations.ToList().Find(x => x.LocalizationId == id);
        }

        public void Update(Localization item)
        {
            var s = _AppDbContext.Localizations.ToList().Find(x => x.LocalizationId == item.LocalizationId);
            s.Name = item.Name;
            s.Symptoms = item.Symptoms;

            _AppDbContext.Localizations.Update(s);
            _AppDbContext.SaveChanges();
        }

        public List<Localization> GetAll()
        {
            return _AppDbContext.Localizations.ToList();
        }
    }
}
