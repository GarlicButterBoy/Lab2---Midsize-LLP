using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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

namespace Lab2___Midsize_LLP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //allows us to move the window
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        //SettingsListViewSelectionChanged Definition
        private void SettingsListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = e.Source as ListView;

            if (listView != null)
            {   //clear the window
                SettingsContentPanel.Children.Clear();
                //if user clicks on "Rent Hardware"
                if (listView.SelectedItem.Equals(HardwareInventory))
                {
                    //Create the Rent Hardware screen (AddRental User Control)
                    Control controlAddRental = new AddRental();
                    //Show it on the settings content panel
                    this.SettingsContentPanel.Children.Add(controlAddRental);
                }
                //if the user clicks on "View Rented Hardware"
                if (listView.SelectedItem.Equals(ViewRentedHardware))
                {
                    //Create the View Rented Hardware screen (ViewRentedHardware User Control)
                    Control controlViewRentedHardware = new ViewExistingRentals();
                    //Show it on the settings content panel
                    this.SettingsContentPanel.Children.Add(controlViewRentedHardware);
                }
            }
        }
    }
}
