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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Digital_Journal
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click_Main_Menu(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            var appSettings = ConfigurationManager.AppSettings;
            SqlConnection sqlCon = new SqlConnection(appSettings["ConnectionString"]);
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                //string query = "INSERT INTO [dbo].[User] ( Password, FirstName, LastName, EmailAddress, PhoneNumber) VALUES(@Password, @Firstname, @Lastname, @Emailaddress, @Phonenumber)";
                string query = "dbo.UpdateUser";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Username", Username.Text);
                sqlCmd.Parameters.AddWithValue("@Password", Password.Password);
                sqlCmd.Parameters.AddWithValue("@Firstname", Firstname.Text);
                sqlCmd.Parameters.AddWithValue("@Lastname", Lastname.Text);
                sqlCmd.Parameters.AddWithValue("@Emailaddress", Emailaddress.Text);
                sqlCmd.Parameters.AddWithValue("@Phonenumber", Phonenumber.Text);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

                Login login = new Login();
                login.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
