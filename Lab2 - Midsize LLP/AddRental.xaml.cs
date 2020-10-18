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
            //Generates a pretty large random number that will be used as an ID for the database
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
                //If any of the textboxes are empty, do not add it to the database
                if (EmployeeName.Text == string.Empty || ItemDescription.Text == string.Empty || ContactNumber.Text == "")
                {
                    MessageBox.Show("None of the fields can be empty! Please fill in the required information.");
                } //if ID IS NOT an integer, do not add to database
                else if (!(ID is int)) //same as (ID.GetType() != typeof(int))
                { //This will never throw since I'm generating a random int, but it has been tested and does work properly
                    MessageBox.Show("Employee ID must be a whole number!");
                }
                else //otherwise add the data to the database
                {

                //Insert Query
                string insertQuery = "INSERT INTO Hardware (empID, name, description, phone) VALUES('" + ID + "', '" + EmployeeName.Text + "', '" + ItemDescription.Text + "', '" + ContactNumber.Text + "')";
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
            }
            catch  (Exception ex) //Throw any errors without crashing the program
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
