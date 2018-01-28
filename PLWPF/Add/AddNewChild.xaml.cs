using BL;
using BE;
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
using PLWPF.windows;

namespace PLWPF.Add
{
    /// <summary>
    /// Interaction logic for AddNewChild.xaml
    /// </summary>
    public partial class AddNewChild : Window
    {
        IBL bl;
        public AddNewChild()
        {
            bl = factoryBL.get_bl();
            InitializeComponent();
            
        }
        //when the Special Needs radio button is checked we fill a label with the acording text
        private void SpecialNeedsChecked(object sender, RoutedEventArgs e)
        {
            SpecialNeedsLabel.Content = "Child needs:";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {//in order to brush the border of the wrong text box to red when a exception is catched, 
         // we must brush all the borders to black every time that we submit new data
            IdBox.BorderBrush = Brushes.Black;
            MotherIdBox.BorderBrush = Brushes.Black;
            BirthDatePicker.BorderBrush = Brushes.Black;
            

            Child temp = new Child();
            int num;
            try
            {//all the possibilities of enter data in the wrong type, as letters to string and so on, are covered here
                if (!int.TryParse(IdBox.Text, out num))
                {
                    IdBox.BorderBrush = Brushes.Red;
                    throw new Exception("You must enter a digit in the Id box.");

                }
                temp.Id = int.Parse(IdBox.Text);

                if (!int.TryParse(MotherIdBox.Text, out num))
                {
                    MotherIdBox.BorderBrush = Brushes.Red;
                    throw new Exception("You must enter a digit in the Mother Id box.");

                }
                temp.Mother_Id = int.Parse(MotherIdBox.Text);
                temp.Birth_Date = Convert.ToDateTime(BirthDatePicker.Text);

            }
            catch (Exception ex)
            {
                //This is a special Message to a Exception in the calendar control, when no date was choosed
                if (ex.Message == "String was not recognized as a valid DateTime.")
                {
                    BirthDatePicker.BorderBrush = Brushes.Red;
                    MessageBox.Show("You must choose a date in the calender");
                    return;
                }
                MessageBox.Show(ex.Message);
                return;
            }

            //these fields don't need exceptions
            temp.First_Name = FirstNameBox.Text;
            
            if (SpecialNeedscheckBox.IsChecked == true)
            {
                temp.Special_Needs = true;
                temp.Needs = SpecialNeedsText.Text;
            }
            if (NoSpecialNeedsCheckBox.IsChecked == true)
            {
                temp.Special_Needs = false;
            }
            try
            {//send the new child object we created, to the BL 
                bl.add_child(temp);
                Close();

            }
            catch (Exception ex)
            {//catches the Exceptions that cames from the other layers
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
