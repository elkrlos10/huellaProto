
namespace huellaProto.Helpers
{
    using Google.Apis.Services;
    using Google.Apis.Urlshortener.v1;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DaimtoShort
    {
		UrlshortenerService service = new UrlshortenerService(new BaseClientService.Initializer()
		{
			ApiKey = "AIzaSyDz5uUicjUP1ytTBtQE9g3Nw1UYRx0YkNM",
			ApplicationName = "Clave de API 1",
		});

		public static string shortenIt(string url)
		{
			UrlshortenerService service = new UrlshortenerService(new BaseClientService.Initializer()
			{
				ApiKey = "AIzaSyDz5uUicjUP1ytTBtQE9g3Nw1UYRx0YkNM",
				ApplicationName = "Clave de API 1",
			});

			var m = new Google.Apis.Urlshortener.v1.Data.Url();
			m.LongUrl = url;
			return service.Url.Insert(m).Execute().Id;
		}

		public static string unShortenIt(string url)
		{
			UrlshortenerService service = new UrlshortenerService(new BaseClientService.Initializer()
			{
				ApiKey = "AIzaSyDz5uUicjUP1ytTBtQE9g3Nw1UYRx0YkNM",
				ApplicationName = "Clave de API 1",
			});
			return service.Url.Get(url).Execute().LongUrl;
		}
	}
}
