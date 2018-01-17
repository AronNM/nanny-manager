using BE;
using BL;
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

namespace PLWPF.Add
{
    /// <summary>
    /// Interaction logic for AddNewContract.xaml
    /// </summary>
    public partial class AddNewContract : Window
    {
        IBL bl;
        public AddNewContract()
        {
            bl = factoryBL.get_bl();
            InitializeComponent();
        }

        private void radioButton_Copy_Checked(object sender, RoutedEventArgs e)
        {
            this.pricelabel.Content = "The hourly price is:";
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            this.pricelabel.Content = "The monthly price is:";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Contract c = new Contract();
            c.Number = int.Parse(this.ContractNumberBox.Text);
            c.Nanny_Id = int.Parse(this.NannyIdBox.Text);
            c.Mother_Id = int.Parse(this.MotherIdBox.Text);
            c.Child_Id = int.Parse(this.ChildIdBox.Text);
            if (this.meeting.IsChecked == true)
            {
                c.Introduction_meeting = true;
            }
            if (this.meeting2.IsChecked == true)
            {
                c.Introduction_meeting = false;
            }
            if (this.signed_yes.IsChecked == true)
            {
                c.Signed = true;
            }
            if (this.signed_no.IsChecked == true)
            {
                c.Signed= false;
            }
            if (this.hourly_yes.IsChecked == true)
            {
                c.Price_Is_Hourly = true;
                c.Hourly_Price = double.Parse(priceBox.Text);
            }
            if (this.hourly_no.IsChecked == true)
            {
                c.Price_Is_Hourly=false;
                c.Monthly_Price = double.Parse(this.priceBox.Text);
            }
            c.Starts = Convert.ToDateTime(this.StartDate.Text);
            c.Ends= Convert.ToDateTime(this.EndDate.Text);

            bl.add_contract_manually(c);
            Close();
        }
    }
}
