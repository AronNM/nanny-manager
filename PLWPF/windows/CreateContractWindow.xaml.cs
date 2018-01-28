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
		

		public void setDistanceInvoke(string text)
		{
			this.distance.Text = text + " KM";
		}

		private void dist(ref Mother mother, ref Nanny nanny)
		{
			Action<string> d = setDistanceInvoke;
			try
			{
				Dispatcher.BeginInvoke(d, new object[] { "LOADING" });

				IBL bl_thread = factoryBL.get_bl();
				string text = bl_thread.get_distance(mother.Home_Address, nanny.Address).ToString();

				Dispatcher.BeginInvoke(d, new object[] { text });
			}
			catch(Exception ex) {
				Dispatcher.BeginInvoke(d, new object[] { "Error while calculating distance!" });
			}
		}



		//public void setLoadingTextInvok(string text)
		//{
		//	this.loadingText.Text = text;
		//}

		//private void displayLoading()
		//{
		//	string text;
		//	for (int i = 0; i < 3; i++)
		//	{
		//		text = "Loading";
		//		for (int j = 0; j < 3; j++)
		//		{
		//			text += ".";

		//			string copy = text;
		//			Action<string> d1 = setLoadingTextInvok;
		//			Dispatcher.BeginInvoke(d1, new object[] { copy });

		//			Thread.Sleep(300);
		//		}
		//	}

		//	Action<string> d = setLoadingTextInvok;
		//	Dispatcher.BeginInvoke(d, new object[] { "" });
		//}


		private void selectedChildRowsButton_Click(object sender, System.EventArgs e)
		{
			//	Thread loading = new Thread(displayLoading);
			//	loading.Start();

			var child = (Child)dataGridNannylessKids.SelectedItem;
			var mother = bl.get_mother((Child)dataGridNannylessKids.SelectedItem);
			var nanny = (Nanny)dataGridRelevantNannies.SelectedItem;
			
			Thread setDistance = new Thread(() => dist(ref mother, ref nanny));
			setDistance.Start();

			names.Text = mother.First_Name + " and " + nanny.First_Name;
			cons.Text = "NEGATIVES\t" + bl.get_negatives(nanny, child, mother);
			timingIssues.Text = "TIMING ISSUES\t" + bl.get_timing_issues(nanny, child, mother);
			pros.Text = "POSITIVES\t" + bl.get_positives(nanny, child, mother);
			//distance.Text = bl.get_distance(mother.Home_Address, nanny.Address).ToString() + " KM";
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
				MessageBox.Show("Error: You must select a child and a nanny!");
			}
		}

		
	}
}
