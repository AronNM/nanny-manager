using System;
using System.Windows;
using System.Windows.Controls;
using BE;
using BL;

namespace PLWPF.delete
{
	/// <summary>
	/// Interaction logic for DeleteMother.xaml
	/// </summary>
	public partial class DeleteMother : Window
	{
		IBL bl;
		Mother mother;

		public DeleteMother()
		{
			bl = factoryBL.get_bl();
			mother = new Mother();
			DataContext = mother;
			InitializeComponent();
			comboBox.ItemsSource = bl.get_mother_list();
			comboBox.DisplayMemberPath = "Id";
			comboBox.SelectedValuePath = "Id";

		}

		private void Remove_Mother_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				//int id = mother.Id;
				bl.delete_mother(mother);
				MessageBox.Show("Mother " + mother.Id +" has been deleted!");
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}
		private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			mother = (Mother)comboBox.SelectedItem;
			label1.Content = mother.ToString();
		}
	}
}
