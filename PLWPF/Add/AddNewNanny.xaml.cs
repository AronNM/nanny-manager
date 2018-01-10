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
    /// Interaction logic for AddNewNanny.xaml
    /// </summary>
    public partial class AddNewNanny : Window
    {
        public AddNewNanny()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                ComboBoxItem newItem = new ComboBoxItem();
                BE.Language l = (BE.Language)i;
                newItem.Content = l.ToString();
  
                comboBox.Items.Add(newItem);


            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }
    }
}
