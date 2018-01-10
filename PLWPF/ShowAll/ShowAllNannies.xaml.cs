using System.Windows;
using System.Windows.Controls;
using BE;
using BL;


namespace PLWPF.ShowAll
{
	/// <summary>
	/// Interaction logic for ShowAllMothers.xaml
	/// </summary>
	public partial class ShowAllNannies : Window
	{
		IBL bl;
		SortNannyBy sortBy;

		public ShowAllNannies()
		{
			SortNannyBy sortBy = new SortNannyBy();
			DataContext = sortBy;
			InitializeComponent();
			bl = factoryBL.get_bl();
			dataGrid.ItemsSource = bl.get_nanny_list();
			comboBox.ItemsSource = bl.get_sort_nannies_by_list();
		}

		private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			sortBy = (SortNannyBy)comboBox.SelectedItem;
			dataGrid.ItemsSource = bl.get_nanny_list(sortBy);
		}
	}
}

