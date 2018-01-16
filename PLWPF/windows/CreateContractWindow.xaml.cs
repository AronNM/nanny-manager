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
using BE;
using BL;
namespace PLWPF.windows
{
	/// <summary>
	/// Interaction logic for CreateContractWindow.xaml
	/// </summary>
	public partial class CreateContractWindow : Window
	{

		IBL bl;
		RoutedEventArgs e = null;

		public CreateContractWindow()
		{
			InitializeComponent();
			bl = factoryBL.get_bl();
			dataGridNannylessKids.ItemsSource = bl.get_all_nannyless_kids();
		}

		private void selectedNanniesRowsButton_Click(object sender, System.EventArgs e)
		{
			var mother = bl.get_mother((Child)dataGridNannylessKids.SelectedItem);

			dataGridRelevantNannies.ItemsSource = bl.check_secondry_match(mother);    //will return initiall match if exists

			names.Text = "";
			cons.Text = "";
			timingIssues.Text = "";
			distance.Text = "";
			pros.Text = "";

		}

		private void selectedChildRowsButton_Click(object sender, System.EventArgs e)
		{
			
			names.Text = bl.get_mother((Child)dataGridNannylessKids.SelectedItem).First_Name + " and " +
							((Nanny)dataGridRelevantNannies.SelectedItem).First_Name;
			cons.Text = "NEGATIVES\t" + bl.get_negatives((Nanny)dataGridRelevantNannies.SelectedItem, (Child)dataGridNannylessKids.SelectedItem,
							bl.get_mother((Child)dataGridNannylessKids.SelectedItem));
			timingIssues.Text = "TIMING ISSUES\t" + bl.get_timing_issues((Nanny)dataGridRelevantNannies.SelectedItem, (Child)dataGridNannylessKids.SelectedItem,
							bl.get_mother((Child)dataGridNannylessKids.SelectedItem));
			distance.Text = bl.get_distance(bl.get_mother((Child)dataGridNannylessKids.SelectedItem).Home_Address,
							((Nanny)dataGridRelevantNannies.SelectedItem).Address).ToString() + " KM";
			pros.Text = "POSITIVES\t" + bl.get_positives((Nanny)dataGridRelevantNannies.SelectedItem, (Child)dataGridNannylessKids.SelectedItem,
							bl.get_mother((Child)dataGridNannylessKids.SelectedItem));
		}

		private void Create_Contract_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Contract cont = new Contract();
				cont.Child_Id = ((Child)dataGridNannylessKids.SelectedItem).Id;
				cont.Mother_Id = bl.get_mother((Child)dataGridNannylessKids.SelectedItem).Id;
				cont.Nanny_Id = ((Nanny)dataGridRelevantNannies.SelectedItem).Id;
				bl.add_contract(cont);

				MessageBox.Show("New contract has been created!");
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}
	}
}
