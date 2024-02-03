using System.ComponentModel.DataAnnotations;

namespace UrlShortener
{
    public class Url
    {
        [Key]
        public string MainUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}
