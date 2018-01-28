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
        //when the Hourly or Monthly radio button is checked we fill a label with the acording text
        private void radioButton_Copy_Checked(object sender, RoutedEventArgs e)
        {
            this.pricelabel.Content = "The hourly price is:";
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            this.pricelabel.Content = "The monthly price is:";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {//in order to brush the border of the wrong text box to red when a exception is catched, 
         // we must brush all the borders to black every time that we submit new data
            #region clear boarders
            ContractNumberBox.BorderBrush = Brushes.Black;
            NannyIdBox.BorderBrush = Brushes.Black;
            ChildIdBox.BorderBrush = Brushes.Black;
            MotherIdBox.BorderBrush = Brushes.Black;
            priceBox.BorderBrush = Brushes.Black;
            StartDate.BorderBrush = Brushes.Black;
            EndDate.BorderBrush = Brushes.Black;
            #endregion
            Contract c = new Contract();
            int num;
            try
            {//all the possibilities of enter data in the wrong type, as letters to string and so on, are covered here
                if (!int.TryParse(ContractNumberBox.Text, out num))
                {
                    ContractNumberBox.BorderBrush = Brushes.Red;
                    throw new Exception("You must enter a digit in the contract number box.");

                }
                c.Number = int.Parse(this.ContractNumberBox.Text);

                if (!int.TryParse(NannyIdBox.Text, out num))
                {
                    NannyIdBox.BorderBrush = Brushes.Red;
                    throw new Exception("You must enter a digit in the Nanny Id box.");

                }
                c.Nanny_Id = int.Parse(this.NannyIdBox.Text);

                if (!int.TryParse(MotherIdBox.Text, out num))
                {
                    MotherIdBox.BorderBrush = Brushes.Red;
                    throw new Exception("You must enter a digit in the Mother Id box.");

                }
                c.Mother_Id = int.Parse(this.MotherIdBox.Text);

                if (!int.TryParse(ChildIdBox.Text, out num))
                {
                    ChildIdBox.BorderBrush = Brushes.Red;
                    throw new Exception("You must enter a digit in the Child Id box.");

                }
                c.Child_Id = int.Parse(this.ChildIdBox.Text);

                if (!int.TryParse(priceBox.Text, out num))
                {
                    priceBox.BorderBrush = Brushes.Red;
                    throw new Exception("You must enter a digit in the Price box.");

                }
                if (this.hourly_yes.IsChecked == true)
                {
                    c.Price_Is_Hourly = true;
                    c.Hourly_Price = double.Parse(priceBox.Text);
                }
                if (this.hourly_no.IsChecked == true)
                {
                    c.Price_Is_Hourly = false;
                    c.Monthly_Price = double.Parse(this.priceBox.Text);
                }
                c.Starts = Convert.ToDateTime(this.StartDate.Text);
                c.Ends = Convert.ToDateTime(this.EndDate.Text);
            }
            catch(Exception ex)
            {

                //This is a special Message to a Exception in the calendar control, when no date was choosed
                if (ex.Message == "String was not recognized as a valid DateTime.")
                {
                    this.StartDate.BorderBrush = Brushes.Red;
                    this.EndDate.BorderBrush = Brushes.Red;
                    MessageBox.Show("You must choose a date in the calender");
                    return;
                }
                MessageBox.Show(ex.Message);
                return;
            }
            //these fields don't need exceptions
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

            try
            {//send the new contract object we created, to the BL 
                bl.add_contract_manually(c);
                Close();
            }
            catch (Exception ex)
            {//catchs the Exceptions that cames from the other layers
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
