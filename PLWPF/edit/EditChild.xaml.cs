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
        {
            bl = factoryBL.get_bl();
            InitializeComponent();
            comboBox.ItemsSource = bl.get_child_list();
            comboBox.DisplayMemberPath = "Id";
            comboBox.SelectedValuePath = "Id";
        }
        private void SpecialNeedsChecked(object sender, RoutedEventArgs e)
        {
            SpecialNeedsLabel.Content = "Child needs:";
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IdBox.BorderBrush = Brushes.Black;
            MotherIdBox.BorderBrush = Brushes.Black;
            BirthDatePicker.BorderBrush = Brushes.Black;
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
        {
            IdBox.BorderBrush = Brushes.Black;
            MotherIdBox.BorderBrush = Brushes.Black;
            BirthDatePicker.BorderBrush = Brushes.Black;
            Child temp = new Child();
            int num;
            try
            {
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

                if (ex.Message == "String was not recognized as a valid DateTime.")
                {
                    BirthDatePicker.BorderBrush = Brushes.Red;
                    MessageBox.Show("You must choose a date in the calender");
                    return;
                }
                MessageBox.Show(ex.Message);
                return;
            }

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
            child = (Child)comboBox.SelectedItem;
            try
            {
                bl.update_child(temp,child.Id);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}

