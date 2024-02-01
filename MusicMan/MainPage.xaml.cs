namespace MusicMan
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            

            SemanticScreenReader.Announce(SearchBtn.Text);
        }
    }

}
