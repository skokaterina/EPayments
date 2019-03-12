using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EPaymentsConsoleTest
{
    class Program
    {
        public static void CheckSites()
        {
            var db = new EPaymentsEntities();

            foreach (var s in db.Sites)
            {
                if (string.IsNullOrEmpty(s.URL))
                    continue;

                s.Status = TestSite(s.URL);                
            }

            db.SaveChanges();
        }

        public static int TestSite(string url)
        {           
            try
            {
                var uri = new Uri(url);

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch(Exception ex)
            {
                return 0;
            }

            return 1;
        }

        static void Main(string[] args)
        {
            CheckSites();

            return;


            var db = new EPaymentsEntities();

            foreach(var s in db.Sites)
            {
                Console.WriteLine(s.Name);
            }

            var myThread = new Thread(new ThreadStart(Count));

            //myThread.IsBackground = true;

            myThread.Start();

            
            Console.ReadLine();
        }

        public static void Count()
        {
            TimerCallback tm = new TimerCallback(AddSite);

            Timer timer = new Timer(tm, null, 0, 5000);                        
        }

        public static void AddSite(object obj)
        {           
            var site = new Sites() { Id = Guid.NewGuid(), Name = DateTime.Now.ToString(), Status = 0 };

            var db = new EPaymentsEntities();

            db.Sites.Add(site);

            db.SaveChanges();

            Console.WriteLine(site.Name);            
        }
    }
}
