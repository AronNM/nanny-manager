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
using BL;
using BE;
using PLWPF.windows;

namespace PLWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		//IBL bl;
		

		public MainWindow()
		{
			InitializeComponent();

			
			
		}

		private void choiceBoxUC_Loaded(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Manage_Mothers_Click(object sender, RoutedEventArgs e)
		{
			ManageMothers manage_mothers = new ManageMothers();
			manage_mothers.ShowDialog();
		}
	}
}
