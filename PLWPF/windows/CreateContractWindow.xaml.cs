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

		public void setLoadingTextInvok(string text)
		{
			this.loadingText.Text = text;
		}

		public void setDistanceInvok(string text)
		{
			this.distance.Text = text;
		}

		private void displayLoading()
		{
			string text;
			for(int i =0; i < 1000; i++)
			{
				text = "Loading";
				for (int j = 0; j < 3; j++)
				{
					text += ".";

					string copy = text;
					Action<string> d1 = setLoadingTextInvok;
					Dispatcher.Invoke(d1, new object[] { copy });

					Thread.Sleep(100);
				}
			}

			Action<string> d = setLoadingTextInvok;
			Dispatcher.BeginInvoke(d, new object[] { "" });
		}

		
		private void displayDistance()
		{
			string distance = bl.get_distance(bl.get_mother((Child)dataGridNannylessKids.SelectedItem).Home_Address,
							((Nanny)dataGridRelevantNannies.SelectedItem).Address).ToString() + " KM";
			Action<string> d1 = setDistanceInvok;
			Dispatcher.Invoke(d1, new object[] { distance });
		}

		private void selectedChildRowsButton_Click(object sender, System.EventArgs e)
		{
			//Thread loading = new Thread(()=>displayLoading(ref loadingText));
			Thread loading = new Thread(displayLoading);
			loading.Start();

			Thread getDistance = new Thread(displayDistance);
			getDistance.Start();

			names.Text = bl.get_mother((Child)dataGridNannylessKids.SelectedItem).First_Name + " and " +
							((Nanny)dataGridRelevantNannies.SelectedItem).First_Name;
			cons.Text = "NEGATIVES\t" + bl.get_negatives((Nanny)dataGridRelevantNannies.SelectedItem, (Child)dataGridNannylessKids.SelectedItem,
							bl.get_mother((Child)dataGridNannylessKids.SelectedItem));
			timingIssues.Text = "TIMING ISSUES\t" + bl.get_timing_issues((Nanny)dataGridRelevantNannies.SelectedItem, (Child)dataGridNannylessKids.SelectedItem,
							bl.get_mother((Child)dataGridNannylessKids.SelectedItem));
			pros.Text = "POSITIVES\t" + bl.get_positives((Nanny)dataGridRelevantNannies.SelectedItem, (Child)dataGridNannylessKids.SelectedItem,
							bl.get_mother((Child)dataGridNannylessKids.SelectedItem));

			while (getDistance.IsAlive)
			{
				//wait and keep loading display alive
			}

			loading.Abort();
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
