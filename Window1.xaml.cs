using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Configuration;
using UserAdminApp.ApiControl;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using UserAdminApp.Apis;

namespace UserAdminApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        // Declare the event
        EmployeeViewModel ViewModel = new EmployeeViewModel();
        public Window1()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            this.DataContext = ViewModel;
        }





        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            var firstName = firstName_txtbox.Text;
            var lastName = lastName_txtbox.Text;
            var employeeId = employeeId_txtbox.Text;

            if (firstName != "" && lastName != "")
            {

                EmployeeModel p = new EmployeeModel
                {
                    Id = "employee-"+Guid.NewGuid().ToString(),
                    FirstName = firstName,
                    LastName = lastName

                };

                this.AUD(p, 0, null);
                ViewModel.EmployeeList.Add(p);
            }
            else
            {

                MessageBox.Show("Fields are required");
            }
        }


private void Button_Click_Update(object sender, RoutedEventArgs e)
{

    var firstName = firstName_txtbox.Text;
    var lastName = lastName_txtbox.Text;
    var id = employeeId_txtbox.Text;

    EmployeeModel p = new EmployeeModel
    {
        FirstName = firstName,
        LastName = lastName

    };

    //Tranform it to Json object


    this.AUD(p, 1, id);
    var index = ViewModel.EmployeeList.FirstOrDefault(employee => employee.Id == id);
    if (index != null)
    {
        ViewModel.EmployeeList.Remove(index);
    }

    EmployeeModel newEmployee = new EmployeeModel
    {
        Id = id,
        FirstName = firstName,
        LastName = lastName
    };

    ViewModel.EmployeeList.Add(newEmployee);

}
private void Button_Click_Delete(object sender, RoutedEventArgs e)
{
    string id = employeeId_txtbox.Text;

    this.AUD(null, 2, id);

    var index = ViewModel.EmployeeList.FirstOrDefault(employee => employee.Id == id);
    if (index != null)
    {
                ViewModel.EmployeeList.Remove(index);
    }
}
private void Button_Click_Reset(object sender, RoutedEventArgs e)
{
    this.resetAll();
}
private void resetAll()
{
    employeeId_txtbox.Text = "";
    firstName_txtbox.Text = "";
    lastName_txtbox.Text = "";

    Add_btn.IsEnabled = true;
    Update_btn.IsEnabled = false;
    Delete_btn.IsEnabled = false;
}

private void reset_btn_Click(object sender, RoutedEventArgs e)
{
    this.resetAll();
}

        private void AUD(EmployeeModel statement, int state, string id)
        {
            String msg = "";


            switch (state)
            {
                case 0:
                    msg = "Row Inserted Successfully!";
                    EmployeeMethods.PostMethod(statement);
                    this.UpdateGrid();
                    this.resetAll();
                    break;

                case 1:
                    msg = "Row Updated Successfully!";
                    EmployeeMethods.PutMethod(statement, id);
                    this.UpdateGrid();
                    this.resetAll();
                    break;

                case 2:
                    msg = "Row Deleted Successfully!";
                    EmployeeMethods.DeleteMethod(id);
                    this.UpdateGrid();
                    this.resetAll();
                    break;

            }
            MessageBox.Show(msg);
        }



        private void MainDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            EmployeeModel employee = (EmployeeModel)dg.SelectedItem;
            if (employee != null)
            {

                employeeId_txtbox.Text = employee.Id.ToString();
                firstName_txtbox.Text = employee.FirstName.ToString();
                lastName_txtbox.Text = employee.LastName.ToString();

                Add_btn.IsEnabled = false;
                Update_btn.IsEnabled = true;
                Delete_btn.IsEnabled = true;

            }
        }

        private void UpdateGrid()
        {
            MainDataGrid.ItemsSource = null;
            MainDataGrid.ItemsSource = ViewModel.EmployeeList;
            MainDataGrid.Items.Refresh();
        }

    }
}





