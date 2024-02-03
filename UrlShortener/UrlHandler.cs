using static System.Net.WebRequestMethods;

namespace UrlShortener
{
    public class UrlHandler
    {
        private static string MakeShortUrl(string longUrl)
        {
            Guid id = Guid.NewGuid();
            return id.ToString().Substring(0, 12);
        }

        public static IResult ShortingUrl(string longUrl)
        {
            if (!longUrl.StartsWith("http://") && !longUrl.StartsWith("https://"))
            {
                longUrl = "http://" + longUrl;
            }

            //Check Already Exist
            var shortUrl = DataAccess.GetShortUrl(longUrl);
            if (shortUrl != longUrl)
            {
                return Results.Ok(new
                {
                    shortUrl = "http://localhost:3001/" + shortUrl + "/"
                });
            }

            Url newUrl = new Url()
            {
                MainUrl = longUrl,
                ShortUrl = MakeShortUrl(longUrl)
            };
            DataAccess.SaveUrl(newUrl);
            return Results.Ok(new
            {
                shortUrl = "http://localhost:3001/" + newUrl.ShortUrl + "/"
            });
        }
        public static IResult RedirectToLongUrl(string shortUrl)
        {
            var mainUrl = DataAccess.GetMainUrl(shortUrl);
            return Results.Redirect(mainUrl);
        }
    }
}
