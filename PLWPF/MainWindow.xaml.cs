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

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Manage_Nannies_Click(object sender, RoutedEventArgs e)
		{
			ManageNannies manage_nannies = new ManageNannies();
			manage_nannies.ShowDialog();
		}

		private void Manage_Mothers_Click(object sender, RoutedEventArgs e)
		{
			ManageMothers manage_mothers = new ManageMothers();
			manage_mothers.ShowDialog();
		}

		private void Manage_Contracts_Click(object sender, RoutedEventArgs e)
		{
			ManageContracts manage_contracts = new ManageContracts();
			manage_contracts.ShowDialog();
		}

		private void Manage_Children_Click(object sender, RoutedEventArgs e)
		{
			ManageChildren manage_children = new ManageChildren();
			manage_children.ShowDialog();
		}

		private void Contract_Wizard_Click(object sender, RoutedEventArgs e)
		{
			CreateContractWindow wizard = new CreateContractWindow();
			wizard.ShowDialog();
		}
	}
}
