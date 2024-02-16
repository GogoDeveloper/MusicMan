using System.Diagnostics;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode.Converter;
using System.Threading.Tasks;

namespace MusicMan
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SearchBtn_Clicked(object sender, EventArgs e)
        {
            //Mit dem holsch de Text vo de SearchBar, egal ob es mitem Button oder mit Enter aktiviert worde isch->    YouTubeLinkSearchBar.Text;
            //THX idiot I know how to code

            VideoDataRetriever videoDataRetriever = new VideoDataRetriever("nBk2QFPwXh0");

            videoDataRetriever.GetStream();
        }
    }
}
