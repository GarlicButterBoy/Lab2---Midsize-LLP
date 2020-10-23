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
using System.Data.SqlClient;

namespace Lab2___Midsize_LLP
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : UserControl
    {
        public Search()
        {
            InitializeComponent();
        }

        private void FillDataGrid()
        {
            try
            {   //Adds the data source, using a string that points to the database
                string connectString = Properties.Settings.Default.connection_string;

                string ID = EmployeeID.Text;
                //Create a connection
                SqlConnection conn = new SqlConnection(connectString);
                //open the connection
                conn.Open();
                //Selection Query
                string selectionQuery = "SELECT * FROM Hardware WHERE empID='" + ID +  "'";
                //Querying the db
                SqlCommand command = new SqlCommand(selectionQuery, conn);
                //Used to retrieve the data
                SqlDataAdapter sda = new SqlDataAdapter(command);
                //Linking the datatable with the database table
                DataTable dt = new DataTable("Hardware");
                //Sets the data
                sda.Fill(dt);
                //Fill the grid to output
                searchGrid.ItemsSource = dt.DefaultView;
            }
            //Throw any errors without crashing the program
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void searchInventory(object sender, RoutedEventArgs e)
        {
            int ID = int.Parse(EmployeeID.Text);
            if (ID.GetType() == typeof(int))
            {
                FillDataGrid();
                EmployeeID.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Employee ID must be a whole number!");
                EmployeeID.Text = string.Empty;
            }

        }

       }
}
