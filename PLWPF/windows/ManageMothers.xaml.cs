using PLWPF.ShowAll;
using PLWPF.delete;
using System.Windows;


namespace PLWPF.windows
{
	/// <summary>
	/// Interaction logic for ManageMothers.xaml
	/// </summary>
	public partial class ManageMothers : Window
	{
		public ManageMothers()
		{
			InitializeComponent();
		}

		private void Add_Mother_Click(object sender, RoutedEventArgs e)
		{
			//AddNewMother manage_mothers = new AddNewMother();
			//manage_mothers.Show();
			Close();
		}

		private void Edit_Mother_Click(object sender, RoutedEventArgs e)
		{
			//EditMother edit_mothers = new EditMother();
			//edit_mothers.Show();
			Close();
		}

		private void Delete_Mother_Click(object sender, RoutedEventArgs e)
		{
			DeleteMother delete_mother = new DeleteMother();
			delete_mother.ShowDialog();
			Close();
		}

		private void Show_All_Mothers_Click(object sender, RoutedEventArgs e)
		{
			ShowAllMothers show_all_mothers = new ShowAllMothers();
			show_all_mothers.ShowDialog();
			Close();
		}
	}
}
