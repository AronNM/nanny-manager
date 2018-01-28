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
	/// </summary>Message
	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Manage_Nannies_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ManageNannies manage_nannies = new ManageNannies();
				manage_nannies.ShowDialog();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private void Manage_Mothers_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ManageMothers manage_mothers = new ManageMothers();
			manage_mothers.ShowDialog();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
}

		private void Manage_Contracts_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ManageContracts manage_contracts = new ManageContracts();
			manage_contracts.ShowDialog();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private void Manage_Children_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				ManageChildren manage_children = new ManageChildren();
			manage_children.ShowDialog();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		private void Contract_Wizard_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				CreateContractWindow wizard = new CreateContractWindow();
			wizard.ShowDialog();
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}

	}
}
