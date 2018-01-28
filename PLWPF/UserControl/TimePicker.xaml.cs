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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF.MyUserControl
{
    /// <summary>
    /// Interaction logic for TimePicker.xaml
    /// </summary>
    public partial class TimePicker : UserControl
    {
        public TimePicker()
        { 
            InitializeComponent();
        }

        private void ChangeBrush(object sender, MouseButtonEventArgs e)
        {//in order to change the control borders to red in case of exception
            // we brush it to black initially
            this.textBox.BorderBrush = Brushes.Black;
            this.textBox1.BorderBrush = Brushes.Black;
        }
    }
}
