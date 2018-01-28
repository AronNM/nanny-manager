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
    /// Interaction logic for EditChild.xaml
    /// </summary>
    public partial class EditChild : Window
    {
        IBL bl;
        Child child;
        public EditChild()
        {//we fill a combo box with all the existent children Ids
            bl = factoryBL.get_bl();
            InitializeComponent();
            comboBox.ItemsSource = bl.get_child_list();
            comboBox.DisplayMemberPath = "Id";
            comboBox.SelectedValuePath = "Id";
        }
        //when the Special Needs radio button is checked we fill a label with the acording text
        private void SpecialNeedsChecked(object sender, RoutedEventArgs e)
        {
            SpecialNeedsLabel.Content = "Child needs:";
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//in order to brush the border of the wrong text box to red when a exception is catched, 
         // we must brush all the borders to black every time that we change the combobox
            IdBox.BorderBrush = Brushes.Black;
            MotherIdBox.BorderBrush = Brushes.Black;
            BirthDatePicker.BorderBrush = Brushes.Black;

            //we create a new object based on the selected Id from the combo box, so we fill all the window controls
            // with this object properties
            child = (Child)comboBox.SelectedItem;
            this.IdBox.Text = child.Id.ToString();
            this.MotherIdBox.Text = child.Mother_Id.ToString();
            this.FirstNameBox.Text = child.First_Name;
            this.BirthDatePicker.Text = child.Birth_Date.ToString();
            if (child.Special_Needs)
            {
                this.SpecialNeedscheckBox.IsChecked = true;
                this.SpecialNeedsText.Text = child.Needs;
            }
            else this.NoSpecialNeedsCheckBox.IsChecked = true;

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
            temp.First_Name = this.FirstNameBox.Text;
            
            if (this.SpecialNeedscheckBox.IsChecked == true)
            {
                temp.Special_Needs = true;
                temp.Needs = this.SpecialNeedsText.Text;
            }
            if (this.NoSpecialNeedsCheckBox.IsChecked == true)
            {
                temp.Special_Needs = false;
            }

            //we create a new object with the data we collect from the window controls, after the updates
            child = (Child)comboBox.SelectedItem;
            try
            {//send the new child object we created, with the changes we made, to the BL
                bl.update_child(temp,child.Id);
                Close();
            }
            catch (Exception ex)
            {//catches the Exceptions that cames from the other layers
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}

