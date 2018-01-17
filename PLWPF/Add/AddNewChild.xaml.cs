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

        private void SpecialNeedsChecked(object sender, RoutedEventArgs e)
        {
            SpecialNeedsLabel.Content = "Child needs:";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Child temp = new Child();
            temp.Id = int.Parse(IdBox.Text);
            temp.Mother_Id = int.Parse(MotherIdBox.Text);
            temp.First_Name = FirstNameBox.Text;
            temp.Birth_Date = Convert.ToDateTime(BirthDatePicker.Text);
            if (SpecialNeedscheckBox.IsChecked == true)
            {
                temp.Special_Needs = true;
                temp.Needs = SpecialNeedsText.Text;
            }
            if (NoSpecialNeedsCheckBox.IsChecked == true)
            {
                temp.Special_Needs = false;
            }
            bl.add_child(temp);
            Close();
        }
    }
}
