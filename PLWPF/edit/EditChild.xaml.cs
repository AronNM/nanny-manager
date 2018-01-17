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
            Child temp = new Child();
            temp.Id = int.Parse(this.IdBox.Text);
            temp.Mother_Id = int.Parse(this.MotherIdBox.Text);
            temp.First_Name = this.FirstNameBox.Text;
            temp.Birth_Date = Convert.ToDateTime(this.BirthDatePicker.Text);
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
            bl.update_child(child.Id, temp);
            Close();
        }
    }
}

