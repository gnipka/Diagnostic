using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestWeb.Models;

namespace TestWeb.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly AppDbContext _AppDbContext;

        public ClientRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public void Create(Client item)
        {
            _AppDbContext.Clients.Add(item);
            _AppDbContext.SaveChanges();
        }

        public void Delete(Client item)
        {
            _AppDbContext.Clients.Remove(item);
            _AppDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var s = _AppDbContext.Clients.ToList().Find(x => x.ClientId == id);
            _AppDbContext.Clients.Remove(s);
            _AppDbContext.SaveChanges();
        }

        public Client Get(int id)
        {
            return _AppDbContext.Clients.ToList().Find(x => x.ClientId == id);
        }

        public List<Client> GetAll()
        {
            return _AppDbContext.Clients.ToList();
        }

        public void Update(Client item)
        {
            var s = _AppDbContext.Clients.ToList().Find(x => x.ClientId == item.ClientId);
            s.ClientGender = item.ClientGender;           

            _AppDbContext.Clients.Update(s);
            _AppDbContext.SaveChanges();
        }
    }
}
