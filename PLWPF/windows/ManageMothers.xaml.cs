using PLWPF.Add;
using PLWPF.delete;
using PLWPF.ShowAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
			AddNewMother manage_mothers = new AddNewMother();
			manage_mothers.Show();
			Close();
		}

		private void Edit_Mother_Click(object sender, RoutedEventArgs e)
		{

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
