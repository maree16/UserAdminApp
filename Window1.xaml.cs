using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserAdminApp.ApiControl;

namespace UserAdminApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
            ObservableCollection<User> items = new ObservableCollection<User>();
            items.Add(new User() { Name = "John Doe", Age = 42, Mail = "john@doe-family.com" });
            items.Add(new User() { Name = "Jane Doe", Age = 39, Mail = "jane@doe-family.com" });
            items.Add(new User() { Name = "Sammy Doe", Age = 13, Mail = "sammy.doe@gmail.com" });
            
            lvDataBinding.ItemsSource = items;
        }


        private async void GetOrganization(object sender, RoutedEventArgs e)
        {
            var organization = await OrganizationProcessor.LoadOrganization();
            buttonText.Text = organization.OrganizationName.ToString();

        }
    }


    public class User
    {
        public string Name { get; set; }

        public int Age { get; set; }
        public string Mail { get; set; }
        public override string ToString()
        {
            return this.Name + ", " + this.Age + " years old" + this.Mail;
        }

    }


}