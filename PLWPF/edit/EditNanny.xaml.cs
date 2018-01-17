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

namespace PLWPF.edit
{
    /// <summary>
    /// Interaction logic for EditNanny.xaml
    /// </summary>
    public partial class EditNanny : Window
    {
        IBL bl;
        Nanny nanny;
        public EditNanny()
        {
            bl = factoryBL.get_bl();
            nanny = new Nanny(); 
            InitializeComponent();
            comboBox.ItemsSource = bl.get_nanny_list();
            comboBox.DisplayMemberPath = "Id";
            comboBox.SelectedValuePath = "Id";
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nanny = (Nanny)comboBox.SelectedItem;
            
        }
    }
}
