using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyUnicam.Model;
using Xamarin.Forms;
using System.ComponentModel;
using MyUnicam.Messaggi;
using MyUnicam.Risorse;

namespace MyUnicam.ViewModel
{
    public class VideoVM : INotifyPropertyChanged
    {
        private IRepositoryVideo _repo;
        public string Titolo { get; private set; }

        private VideoM _videoSelezionato;
        public VideoM VideoSelezionato
        {
            get
            {
                return _videoSelezionato;
            }
            set
            {
                _videoSelezionato = value;
                if (_videoSelezionato!=null)
                    Device.OpenUri(new Uri(_videoSelezionato.Link));
                _videoSelezionato = null;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("VideoSelezionato"));
            }
        }
        public VideoM[] CanaleYouTube { get; set; }

        public VideoVM()
        {
            this.Titolo = Dizionario.ResourceManager.GetString("Video", Dizionario.Culture);
            _repo = DependencyService.Get<IRepositoryVideo>();
            _repo.Elenca().ContinueWith(results =>
                {
                    Video = results.Result;
                });

            CanaleYouTube = new VideoM[]
            { 
                new VideoM{
                    Immagine = "LogoYT.png",
                    Link = "https://m.youtube.com/user/VideoUnicam",
                    Nome = Dizionario.CanaleYT
                }
            };

        }

        private IEnumerable<VideoM> _video;
        public IEnumerable<VideoM> Video
        {
            get
            {
                return _video;
            }
            private set
            {
                _video = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Video"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
