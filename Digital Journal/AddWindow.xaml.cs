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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
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
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            var appSettings = ConfigurationManager.AppSettings;
            SqlConnection sqlCon = new SqlConnection(appSettings["ConnectionString"]);
            try
            {                
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                string query = "dbo.insertJournal";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@JournalName", JournalName.Text);
                sqlCmd.Parameters.AddWithValue("@Data", Data.Text);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
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
