using System;
using System.Windows;
using System.Windows.Controls;
using BE;
using BL;

namespace PLWPF.delete
{
	/// <summary>
	/// Interaction logic for DeleteChild.xaml
	/// </summary>
	public partial class DeleteChild : Window
	{
		IBL bl;
		Child child;

		public DeleteChild()
		{
			bl = factoryBL.get_bl();
			child = new Child();
			DataContext = child;
			InitializeComponent();
			comboBox.ItemsSource = bl.get_child_list();
			comboBox.DisplayMemberPath = "Id";
			comboBox.SelectedValuePath = "Id";

		}

		private void Remove_Child_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				//int id = child.Id;
				bl.delete_child(child);
				MessageBox.Show("Child " + child.Id + " has been deleted!");
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}
		private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			child = (Child)comboBox.SelectedItem;
			label1.Content = child.ToString();
		}
	}
}
