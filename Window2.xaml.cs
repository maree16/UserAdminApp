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
    public partial class Window2 : Window
    {
        // Declare the event
        OrganizationViewModel ViewModel = new OrganizationViewModel();
        public Window2()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            this.DataContext = ViewModel;
        }


        
    
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            var organizationName = organizationName_txtbox.Text;
            var organizationType = organizationType_txtbox.Text;
            var organizationUrl = organizationUrl_txtbox.Text;

            if (organizationName != "" && organizationUrl != "" && organizationType != "" && organizationRegistrationNumber_txtbox.Text != "")
            {
                var organization_ResgirationNumber = Convert.ToInt16(organizationRegistrationNumber_txtbox.Text);

                OrganizationModel p = new OrganizationModel
                {
                    Id = "organization-"+ Guid.NewGuid().ToString(),
                    OrganizationName = organizationName,
                    OrganizationType = organizationType,
                    OrganizationUrl = organizationUrl,
                    OrganizationRegistrationNumber = organization_ResgirationNumber


                };

                this.AUD(p, 0, null);
                 ViewModel.OrganizationList.Add(p);
            }
            else
            {

               MessageBox.Show("Fields are required");
            }
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {

            var id = organizationId_txtbox.Text;
            var organization_Name = organizationName_txtbox.Text;
            var organization_Type = organizationType_txtbox.Text;
            var organization_Url = organizationUrl_txtbox.Text;
            var organization_ResgirationNumber = Convert.ToInt32(organizationRegistrationNumber_txtbox.Text);

            OrganizationModel p = new OrganizationModel
            {
                OrganizationName = organization_Name,
                OrganizationType = organization_Type,
                OrganizationUrl = organization_Url,
                OrganizationRegistrationNumber = organization_ResgirationNumber


            };

            //Tranform it to Json object
            OrganizationModel newM = new OrganizationModel
            {
                Id = organizationId_txtbox.Text,
                OrganizationName = organization_Name,
                OrganizationType = organization_Type,
                OrganizationUrl = organization_Url,
                OrganizationRegistrationNumber = organization_ResgirationNumber


            };

            var OldModel = ViewModel.OrganizationList.FirstOrDefault(organization => organization.Id == id);
            if (OldModel != null)
            {
               ViewModel.OrganizationList.Remove(OldModel);
            }

            ViewModel.OrganizationList.Add(newM);
            this.AUD(p, 1, id);

        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            string id = organizationId_txtbox.Text;

            var OldModel = ViewModel.OrganizationList.FirstOrDefault(organization => organization.Id == id);
            if (OldModel != null)
            {
                ViewModel.OrganizationList.Remove(OldModel);
            }


            this.AUD(null, 2, id);

        }
        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            this.resetAll();
        }
        private void resetAll()
        {
            organizationId_txtbox.Text = "";
            organizationName_txtbox.Text = "";
            organizationType_txtbox.Text = "";
            organizationUrl_txtbox.Text = "";
            organizationRegistrationNumber_txtbox.Text = "";

            Add_btn.IsEnabled = true;
            Update_btn.IsEnabled = false;
            Delete_btn.IsEnabled = false;
        }

        private void reset_btn_Click(object sender, RoutedEventArgs e)
        {
            this.resetAll();
        }

        private void AUD(OrganizationModel statement, int state, string id)
        {
            String msg = "";


            switch (state)
            {
                case 0:
                    msg = "Row Inserted Successfully!";
                    OrganizationMethods.PostMethod(statement);
                    this.UpdateGrid();
                    this.resetAll();
                    break;

                case 1:
                    msg = "Row Updated Successfully!";
                    OrganizationMethods.PutMethod(statement, id);
                    this.UpdateGrid();
                    this.resetAll();
                    break;

                case 2:
                    msg = "Row Deleted Successfully!";
                    OrganizationMethods.DeleteMethod(id);
                    this.UpdateGrid();
                    this.resetAll();
                    break;

            }
            MessageBox.Show(msg);
        }


        private void MainDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            OrganizationModel organization = (OrganizationModel)dg.SelectedItem;
            if (organization != null)
            {

                organizationId_txtbox.Text = organization.Id.ToString();

                organizationName_txtbox.Text = organization.OrganizationName.ToString();
                organizationUrl_txtbox.Text = organization.OrganizationUrl.ToString();
                organizationType_txtbox.Text = organization.OrganizationType.ToString();
                organizationRegistrationNumber_txtbox.Text = organization.OrganizationRegistrationNumber.ToString();

                Add_btn.IsEnabled = false;
                Update_btn.IsEnabled = true;
                Delete_btn.IsEnabled = true;

            }
        }

        private void UpdateGrid() 
        {
            MainDataGrid.ItemsSource = null;
            MainDataGrid.ItemsSource = ViewModel.OrganizationList;
            MainDataGrid.Items.Refresh();
        }
        
    }
}


