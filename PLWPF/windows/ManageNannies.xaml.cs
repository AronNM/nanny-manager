using PLWPF.ShowAll;
using PLWPF.delete;
using System.Windows;

namespace PLWPF
{
	/// <summary>
	/// Interaction logic for ManageNannies.xaml
	/// </summary>
	public partial class ManageNannies : Window
	{
		public ManageNannies()
		{
			InitializeComponent();
		}

		private void Add_Nanny_Click(object sender, RoutedEventArgs e)
		{
			//AddNewNanny manage_Nannies = new AddNewNanny();
			//manage_Nannies.Show();
			Close();
		}

		private void Edit_Nanny_Click(object sender, RoutedEventArgs e)
		{
			//EditNanny edit_Nannies = new EditNanny();
			//edit_Nannies.Show();
			Close();
		}

		private void Delete_Nanny_Click(object sender, RoutedEventArgs e)
		{
			DeleteNanny delete_Nanny = new DeleteNanny();
			delete_Nanny.ShowDialog();
			Close();
		}

		private void Show_All_Nannies_Click(object sender, RoutedEventArgs e)
		{
			ShowAllNannies show_all_Nannies = new ShowAllNannies();
			show_all_Nannies.ShowDialog();
			Close();
		}
	}
}
