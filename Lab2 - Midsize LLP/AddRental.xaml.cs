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
using System.Data.SqlClient;

namespace Lab2___Midsize_LLP
{
    /// <summary>
    /// Interaction logic for AddRental.xaml
    /// </summary>
    public partial class AddRental : UserControl
    {
        public AddRental()
        {
            InitializeComponent();
        }
        //Generates the ID
        public int random()
        {
            Random rand = new Random();
            int number = rand.Next();
            return number;
        }

        private void addHardwareToDatabase(object sender, RoutedEventArgs e)
        {
            try
            {
                //Retrieve the database location
                string connectString = Properties.Settings.Default.connection_string;
                //Create a connection
                SqlConnection conn = new SqlConnection(connectString);
                //open the conn
                conn.Open();

                //generate a random ID
                int ID = random();

                //Insert Query
                string insertQuery = "INSERT INTO Hardware (empID, name, desc, phone) VALUES('" + ID + "', '" + EmployeeName.Text + "', '" + ItemDescription.Text + "', '" + ContactNumber.Text + "')";
                //create the command
                SqlCommand command = new SqlCommand(insertQuery, conn);
                //execute the query
                command.ExecuteNonQuery();
                //close the connection
                conn.Close();

                //Show a Popup Message if the record is added successfully
                MessageBox.Show("Congrats! You have Rented That Hardware Item!");
                //Empty the text boxes
                EmployeeName.Text = string.Empty;
                ItemDescription.Text = string.Empty;
                ContactNumber.Text = string.Empty;
            }
            catch  (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
