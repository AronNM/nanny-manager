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

namespace PLWPF.edit
{
    /// <summary>
    /// Interaction logic for EditControl.xaml
    /// </summary>
    public partial class EditContract : Window
    {
        IBL bl;
        Contract c;
        public EditContract()
        {
            bl = factoryBL.get_bl();
            InitializeComponent();
            comboBox.ItemsSource = bl.get_contract_list();
            comboBox.DisplayMemberPath = "Number";
            comboBox.SelectedValuePath = "Number";

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            c = (Contract)comboBox.SelectedItem;
            this.ContractNumberBox.Text = c.Number.ToString();
            this.NannyIdBox.Text = c.Nanny_Id.ToString();
            this.MotherIdBox.Text = c.Mother_Id.ToString();
            this.ChildIdBox.Text = c.Child_Id.ToString();
            if(c.Introduction_meeting)
            {
                this.meeting.IsChecked = true;
            }
            else this.meeting2.IsChecked = true;

            if (c.Signed)
            {
                this.signed_yes.IsChecked = true;
            }
            else this.signed_no.IsChecked = true;

            if (c.Price_Is_Hourly)
            {
                this.hourly_yes.IsChecked = true;
                this.priceBox.Text = c.Hourly_Price.ToString();
            }
            else
            {
                this.hourly_no.IsChecked = true;
                this.priceBox.Text = c.Monthly_Price.ToString();
            }

            this.StartDate.Text = c.Starts.ToString();
            this.EndDate.Text = c.Ends.ToString();


        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Contract temp = new Contract();
            temp.Number = int.Parse(this.ContractNumberBox.Text);
            temp.Nanny_Id = int.Parse(this.NannyIdBox.Text);
            temp.Mother_Id = int.Parse(this.MotherIdBox.Text);
            temp.Child_Id = int.Parse(this.ChildIdBox.Text);
            if(this.meeting.IsChecked==true)
            {
                temp.Introduction_meeting = true;
            }
            if (this.meeting2.IsChecked == true)
            {
                temp.Introduction_meeting = false;
            }
            if(this.signed_yes.IsChecked==true)
            {
                temp.Signed = true;
            }
            if (this.signed_no.IsChecked == true)
            {
                temp.Signed = false;
            }
            if(this.hourly_yes.IsChecked==true)
            {
                temp.Price_Is_Hourly = true;
                temp.Hourly_Price = double.Parse(this.priceBox.Text);
            }
            if (this.hourly_no.IsChecked == true)
            {
                temp.Price_Is_Hourly = false;
                temp.Monthly_Price = double.Parse(this.priceBox.Text);
            }
            temp.Starts = Convert.ToDateTime(this.StartDate.Text);
            temp.Ends = Convert.ToDateTime(this.EndDate.Text);
            c = (Contract)comboBox.SelectedItem;
            bl.update_contract(c.Number, temp);
            Close();
        }

        private void radioButton_Copy_Checked(object sender, RoutedEventArgs e)
        {
            this.pricelabel.Content = "The hourly price is:";
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            this.pricelabel.Content = "The monthly price is:";
        }
    }
}
