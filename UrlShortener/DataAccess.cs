using System;

namespace UrlShortener
{
    public class DataAccess
    {
        public static string SaveUrl(Url url)
        {
            using (var db = new Database())
            {
                try
                {
                    db.Urls.Add(url);
                    db.SaveChanges();
                }
                catch
                {
                }
                return url.ShortUrl;
            }
        }
        public static string GetMainUrl(string url)
        {
            using (var db = new Database())
            {
                var dbUrl = db.Urls.FirstOrDefault(u => u.ShortUrl == url);
                if (dbUrl == null)
                {
                    return url;
                }
                return dbUrl.MainUrl;
            }
        }
        public static string GetShortUrl(string url)
        {
            using (var db = new Database())
            {
                var dbUrl = db.Urls.FirstOrDefault(u =>u.MainUrl == url);
                if (dbUrl == null)
                {
                    return url;
                }
                return dbUrl.ShortUrl;
            }
        }
    }
}
