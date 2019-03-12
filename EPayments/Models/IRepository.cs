using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPayments.Models
{
    public interface IRepository : IDisposable
    {
        List<Site> Sites { get; }
        Site Find(Guid id);
        void Create(Site item);
        void Update(Site item);
        void Save();
    }
}