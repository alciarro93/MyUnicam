using MyUnicam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MyUnicam.WinPhone.Servizi.VideoRestSharpWinPhone))]
namespace MyUnicam.WinPhone.Servizi
{
    class VideoRestSharpWinPhone: IRepositoryVideo
    {
        public async Task<IEnumerable<VideoM>> Elenca()
        {
            var client = new RestSharp.RestClient("https://www.googleapis.com");
            var request = new RestSharp.RestRequest("youtube/v3/search", RestSharp.Method.GET);
            request.AddParameter("key", "AIzaSyCFDoyf0RrB8j1PH83VORl2vwqbrdXYmf8");
            request.AddParameter("channelId", "UCqqTeN59k2ufzVAOg0yEhnQ");
            request.AddParameter("part", "snippet,id");
            request.AddParameter("order", "date");
            request.AddParameter("maxResults", "20");
            var response=await client.ExecuteGetTaskAsync<RisultatiVideo>(request);
            return response.Data.items.Select(i => new VideoM
            {
                Nome = i.snippet.title,
                Immagine = ImageSource.FromUri(new Uri(i.snippet.thumbnails._default.url)),
                Data = i.snippet.publishedAt,
                Link = string.Format("http://www.youtube.com/watch?v={0}", i.id.videoId)
            });
        }
    }
}
