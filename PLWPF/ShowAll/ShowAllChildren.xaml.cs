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
using BE;
using BL;

namespace PLWPF.ShowAll
{
	/// <summary>
	/// Interaction logic for ShowAllChildren.xaml
	/// </summary>
	public partial class ShowAllChildren : Window
	{
		IBL bl;
		RoutedEventArgs e = null;

		public ShowAllChildren()
		{
			InitializeComponent();
			bl = factoryBL.get_bl();
			All_Checked(this, e);
		}

		private void All_Checked(object sender, RoutedEventArgs e)
		{
			dataGrid.ItemsSource = bl.get_child_list();
			
		}

		private void Nannyless_Checked(object sender, RoutedEventArgs e)
		{
			dataGrid.ItemsSource = bl.get_all_nannyless_kids();
		}
		
		private void specialNeeds_Checked(object sender, RoutedEventArgs e)
		{
			dataGrid.ItemsSource = bl.get_all_specialNeeds_kids();
		}

		private void All_unChecked(object sender, RoutedEventArgs e)
		{
			All_Checked(this, e);

		}

		private void Nannyless_unChecked(object sender, RoutedEventArgs e)
		{
			All_Checked(this, e);
		}

		private void specialNeeds_unChecked(object sender, RoutedEventArgs e)
		{
			All_Checked(this, e);
		}
	}
}
