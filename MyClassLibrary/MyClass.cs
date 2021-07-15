using System;
#if NET40
using System.Net;
#else
using System.Net.Http;
using System.Threading.Tasks;
#endif
namespace MyClassLibrary
{
    public class MyClass
    {
        // Pre-processor if ha kheyli be kar miad injor mavaghe>
#if NET40 // net framework 4.0 bod

        public void HelloWorld()
        {
            Console.WriteLine("Hello World from .NET Framework 4.0");
        }

#elif NET // NET e tanha yani net 5 ya 6

        public void HelloWorld()
        {
            Console.WriteLine("Hello World from .NET 5.0/6.0");
        }
#else // Netstandard ya netcoreapp3.1 ya netframework 4.5.2 bod

        public void HelloWorld()
        {
            Console.WriteLine("Hello World from .netstandard ya net .core 3.1 ya .netframework 4.5.2 bod");
        }

#endif
        // ya
        public string HelloWorld2()
        {
            string str;
#if NET40 
            str = "Hello World from .NET Framework 4.0";
#elif NET
            str = "Hello World from .NET 5.0/6.0";
#else
            str = "Hello World from .netstandard ya net .core 3.1 ya .netframework 4.5.2 bod";
#endif
            return str;
        }

        // ye chiz e bahal tar
        public
#if NET40
            string
#else
       async Task<string>
#endif
            GetSomethingFromNet()
        {
            var url = "https://barnamenevis.org/showthread.php?566479-کار-کردن-DLL-ساخته-شده-برای-همه-ورژن-های-NET";
#if NET40
            using (var webClient = new WebClient())
                return webClient.DownloadString(url);
#else
            using (var httpClient = new HttpClient())
                return await (await httpClient.GetAsync(new Uri(url)).ConfigureAwait(false)).Content.ReadAsStringAsync().ConfigureAwait(false);
#endif
        }

        // yejore dg>
        public
#if NET40
            string
            GetSomethingFromInternet()
#else
       async Task<string>
            GetSomethingFromInternetAsync()
#endif
        {
            var url = "https://barnamenevis.org/showthread.php?566479-کار-کردن-DLL-ساخته-شده-برای-همه-ورژن-های-NET";
#if NET40
            using (var webClient = new WebClient())
                return webClient.DownloadString(url);
#else
            using (var httpClient = new HttpClient())
                return await (await httpClient.GetAsync(new Uri(url)).ConfigureAwait(false)).Content.ReadAsStringAsync().ConfigureAwait(false);
#endif
        }
    }
}
