using PLWPF.Add;
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

namespace PLWPF.windows
{
	/// <summary>
	/// Interaction logic for Manage_Children.xaml
	/// </summary>
	public partial class ManageChildren : Window
	{
		public ManageChildren()
		{
			InitializeComponent();
		}

        private void Add_Child_Click(object sender, RoutedEventArgs e)
        {
            AddNewChild manage_mothers = new AddNewChild();
            manage_mothers.ShowDialog();
        }

        private void Edit_Child_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Child_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Show_All_Children_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
