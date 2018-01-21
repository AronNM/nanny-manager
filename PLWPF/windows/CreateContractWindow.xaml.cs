using System;
using System.Windows;
using BE;
using BL;
using System.Threading;
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

		public void setTextInvok(string text)
		{
			this.loadingText.Text = text;
		}
			
		private void displayLoading()
		{
			string text;
			for(int i =0; i < 10; i++)
			{
				text = "Loading";
				for (int j = 0; j < 4; j++)
				{
					Thread.Sleep(100);
					text += ".";

					Action<string> d = setTextInvok;
					Dispatcher.BeginInvoke(d, new object[] { text });
				}
			}
		}

		private void selectedChildRowsButton_Click(object sender, System.EventArgs e)
		{
			//Thread loading = new Thread(()=>displayLoading(ref loadingText));
			Thread loading = new Thread(displayLoading);
			loading.Start();

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
			//loading.Suspend();
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
