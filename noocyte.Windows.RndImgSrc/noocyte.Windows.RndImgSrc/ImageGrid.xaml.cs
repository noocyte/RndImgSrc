using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace noocyte.Windows.RndImgSrc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ImageGrid : Page
    {
       // A pointer back to the main page which is used to gain access to the input and output frames and their content.
        MainPage rootPage = null;

        public ImageGrid()
        {
            InitializeComponent();
            PopulateGrid();
            
        }

        private async void PopulateGrid()
        {
            GoogleImageSearch gis = new GoogleImageSearch();
            ItemGridView.ItemsSource = await gis.ExaminePhotos("test");
        }

     
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Get a pointer to our main page
            rootPage = e.Parameter as MainPage;            
        }
    }
}
