using UrlShortener;
namespace UrlShortener
{
    public class Program
    {
        public static void Main(String[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapPost("/urlshorting/", UrlHandler.ShortingUrl);

            app.MapGet("/{shortUrl}/", UrlHandler.RedirectToLongUrl);

            app.Run("http://localhost:3001");
        }
    }
}
