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
	/// Interaction logic for ManageNannies.xaml
	/// </summary>
	public partial class ManageNannies : Window
	{
		public ManageNannies()
		{
			InitializeComponent();
		}

        private void Add_Mother_Click(object sender, RoutedEventArgs e)
        {
            AddNewNanny manage_children = new AddNewNanny();
            manage_children.ShowDialog();
        }

        private void Edit_Mother_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Mother_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Show_All_Mothers_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
