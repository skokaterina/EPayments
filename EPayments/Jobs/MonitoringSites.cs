using EPayments.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace EPayments.Jobs
{
    public class MonitoringSites : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {            
            var db = new SiteContext();

            var sitesList = db.Sites.Where(x => x.IsBlocked != true).ToList();

            foreach (var s in sitesList)
            {
                if (string.IsNullOrEmpty(s.URL))
                    continue;
                
                try
                {
                    var uri = new Uri(s.URL);
                    await Task.Run(() => WebRequest.Create(uri).GetResponse()); 
                    //WebRequest.Create(uri).GetResponse();
                }
                catch (Exception ex)
                {
                    s.Status = 0;
                    continue;
                }

#if DEBUG
                s.Status++;
#else
                s.Status = 1;
#endif
            }

            await Task.Run(() => db.SaveChanges());            
        }        
    }
}
