using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
        }


        // Add loadingrow function In datagrid for that
        //void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        //{
        //    e.Row.Header = (e.Row.GetIndex()).ToString();
        //}

        private void UpdateDataGrid()
        {
            DataTable dt = new DataTable();
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
            employees.Add(new Employee() { FirstName = "John", LastName = " Doe", });
            employees.Add(new Employee() { FirstName = "Jane", LastName = " Doe", });
            employees.Add(new Employee() { FirstName = "Sammy", LastName = " Doe", });

     
            MainDataGrid.ItemsSource = employees;

        }


        private async void GetOrganization(object sender, RoutedEventArgs e)
        {
            var organization = await OrganizationProcessor.LoadOrganization();
//            buttonText.Text = organization.OrganizationName.ToString();

        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.UpdateDataGrid();
        }
    }


    public class Employee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
       
   
    }


}