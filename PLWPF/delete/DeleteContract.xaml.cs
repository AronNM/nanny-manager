using System;
using System.Windows;
using System.Windows.Controls;
using BE;
using BL;

namespace PLWPF.delete
{
	/// <summary>
	/// Interaction logic for DeleteContract.xaml
	/// </summary>
	public partial class DeleteContract : Window
	{
		IBL bl;
		Contract contract;

		public DeleteContract()
		{
			bl = factoryBL.get_bl();
			contract = new Contract();
			DataContext = contract;
			InitializeComponent();
			comboBox.ItemsSource = bl.get_contract_list();
			comboBox.DisplayMemberPath = "Number";
			comboBox.SelectedValuePath = "Number";

		}

		private void Remove_Contract_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				int id = contract.Number;
				bl.delete_contract(id);
				MessageBox.Show("contract " + id + " has been deleted!");
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}
		private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			contract = (Contract)comboBox.SelectedItem;
			label1.Content = contract.ToString();
		}
	}
}
