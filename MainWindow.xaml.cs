using System.Threading.Tasks;
using System.Windows;
using UserAdminApp.ApiControl;

namespace UserAdminApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private async Task GetOrganization(int organizationCount = 0)
        {
            var organization = await OrganizationProcessor.LoadOrganization(organizationCount);

        }

        private async void Load_Record(object sender, RoutedEventArgs e)
        {
            await GetOrganization();  
        }
    }
}
