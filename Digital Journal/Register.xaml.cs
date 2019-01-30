using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;


namespace Digital_Journal
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var appSettings = ConfigurationManager.AppSettings;
            SqlConnection sqlCon = new SqlConnection(appSettings["ConnectionString"]);
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                //string query = "INSERT INTO [dbo].[User] (Username, Password, FirstName, LastName, EmailAddress, PhoneNumber) VALUES(@Username, @Password, @Firstname, @Lastname, @Emailaddress, @Phonenumber)";
                string query = "dbo.insertUser";
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
