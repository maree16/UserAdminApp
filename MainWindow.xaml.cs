using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TheRThemes;
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
        
        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            switch (int.Parse(((MenuItem)sender).Uid))
            {
                case 0: ThemesController.SetTheme(ThemesController.ThemeTypes.Light); break;
                case 1: ThemesController.SetTheme(ThemesController.ThemeTypes.Blue); break;
                case 2: ThemesController.SetTheme(ThemesController.ThemeTypes.Dark); break;
                case 3: ThemesController.SetTheme(ThemesController.ThemeTypes.ColourfulDark); break;
            }
            e.Handled = true;
        }

        
        private void EButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 employeeWindow = new Window1();
            employeeWindow.Show();
        }

        private void OButton_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 organizationWindow = new Window2();
            organizationWindow.Show();
        }
    }
}
   

 