using System;
using System.Windows;
using System.Windows.Controls;
using BE;
using BL;

namespace PLWPF.delete
{
	/// <summary>
	/// Interaction logic for DeleteNanny.xaml
	/// </summary>
	public partial class DeleteNanny : Window
	{
		IBL bl;
		Nanny nanny;

		public DeleteNanny()
		{
			bl = factoryBL.get_bl();
			nanny = new Nanny();
			DataContext = nanny;
			InitializeComponent();
			comboBox.ItemsSource = bl.get_nanny_list();
			comboBox.DisplayMemberPath = "Id";
			comboBox.SelectedValuePath = "Id";

		}

		private void Remove_Nanny_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				int id = nanny.Id;
				bl.delete_nanny(id);
				MessageBox.Show("Nanny " + id + " has been deleted!");
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}
		private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			nanny = (Nanny)comboBox.SelectedItem;
			label1.Content = nanny.ToString();
		}
	}
}
