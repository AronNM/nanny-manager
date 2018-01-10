using PLWPF.ShowAll;
using PLWPF.delete;
using System.Windows;

namespace PLWPF.windows
{
	/// <summary>
	/// Interaction logic for ManageContracts.xaml
	/// </summary>
	public partial class ManageContracts : Window
	{
		public ManageContracts()
		{
			InitializeComponent();
		}

		private void Add_Contract_Click(object sender, RoutedEventArgs e)
		{
			//AddNewContract manage_Contracts = new AddNewContract();
			//manage_Contracts.Show();
			Close();
		}

		private void Edit_Contract_Click(object sender, RoutedEventArgs e)
		{
			//EditContract manage_Contracts = new EditContract();
			//manage_Contracts.Show();
			Close();
		}

		private void Delete_Contract_Click(object sender, RoutedEventArgs e)
		{
			DeleteContract delete_Contract = new DeleteContract();
			delete_Contract.ShowDialog();
			Close();
		}

		private void Show_All_Contracts_Click(object sender, RoutedEventArgs e)
		{
			ShowAllContracts show_all_Contracts = new ShowAllContracts();
			show_all_Contracts.ShowDialog();
			Close();
		}
	}
}