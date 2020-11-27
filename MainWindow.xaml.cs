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

        /* private async void GetOrganization(object sender, RoutedEventArgs e)
        {
            var organization = await OrganizationProcessor.LoadOrganization();
           /// buttonText.Text = organization.OrganizationRegistrationNumber.ToString();
           
        }
        */
        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    }

 