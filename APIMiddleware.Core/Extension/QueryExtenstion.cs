using System;
using System.IO;

namespace APIMiddleware.Core.Extenstion
{
    public static class QueryExtenstion
    {
        private readonly static Uri SomeBaseUri = new Uri("http://canbeanything");
        public static string GetFileNameFromUrl(string url)
        {
            Uri uri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
                uri = new Uri(SomeBaseUri, url);

            return Path.GetFileNameWithoutExtension(uri.LocalPath);
        }
    }
}
