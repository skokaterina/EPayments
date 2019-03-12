using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPayments.Models
{   
    public class SiteRepository : IRepository
    {
        SiteContext db = new SiteContext();

        public List<Site> Sites
        {
            get
            {
                return db.Sites.Where(x => x.IsBlocked != true).ToList();
            }
        }

        public void Create(Site item)
        {
            item.Id = Guid.NewGuid();
            db.Sites.Add(item);                 
        }

        public Site Find(Guid id)
        {
            return db.Sites.Find(id);
        }

        public void Update(Site site)
        {
            var _site = db.Sites.Find(site.Id);

            _site.Name = site.Name;
            _site.URL = site.URL;
            _site.IsBlocked = site.IsBlocked;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}