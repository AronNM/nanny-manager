using PLWPF.ShowAll;
using PLWPF.delete;
using System.Windows;
using PLWPF.Add;

namespace PLWPF.windows
{
	/// <summary>
	/// Interaction logic for Manage_Children.xaml
	/// </summary>
	public partial class ManageChildren : Window
	{
		public ManageChildren()
		{
			InitializeComponent();
		}

		private void Add_Child_Click(object sender, RoutedEventArgs e)
		{
			AddNewChild addchild = new AddNewChild();
			addchild.Show();
			Close();
		}

		private void Edit_Child_Click(object sender, RoutedEventArgs e)
		{
			//EditChild edit_Children = new EditChild();
			//edit_Children.Show();
			Close();
		}

		private void Delete_Child_Click(object sender, RoutedEventArgs e)
		{
			DeleteChild delete_Child = new DeleteChild();
			delete_Child.ShowDialog();
			Close();
		}

		private void Show_All_Children_Click(object sender, RoutedEventArgs e)
		{
			ShowAllChildren show_all_Children = new ShowAllChildren();
			show_all_Children.ShowDialog();
			Close();
		}
	}
}
