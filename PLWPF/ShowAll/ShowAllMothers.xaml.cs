using System.Windows;
using System.Windows.Controls;
using BE;
using BL;


namespace PLWPF.ShowAll
{
	/// <summary>
	/// Interaction logic for ShowAllMothers.xaml
	/// </summary>
	public partial class ShowAllMothers : Window
	{
		IBL bl;
		SortMotherBy sortBy;

		public ShowAllMothers()
		{
			SortMotherBy sortBy = new SortMotherBy();
			DataContext = sortBy;
			InitializeComponent();
			bl = factoryBL.get_bl();			
			dataGrid.ItemsSource = bl.get_mother_list();
			comboBox.ItemsSource = bl.get_sort_mothers_by_list();
		}

		private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			sortBy = (SortMotherBy)comboBox.SelectedItem;
			dataGrid.ItemsSource = bl.get_mother_list(sortBy);
		}
	}
}

