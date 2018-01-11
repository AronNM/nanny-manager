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

namespace PLWPF.ShowAll
{
	/// <summary>
	/// Interaction logic for ShowAllContracts.xaml
	/// </summary>
	public partial class ShowAllContracts : Window
	{
		IBL bl;
		ContractCondition condition;
		RoutedEventArgs e = null;

		public ShowAllContracts()
		{
			DataContext = condition;
			InitializeComponent();
			bl = factoryBL.get_bl();
			All_Checked(this, e);
		}

		private void All_Checked(object sender, RoutedEventArgs e)
		{
			comboBox.ItemsSource = null;
			dataGrid.ItemsSource = bl.get_contract_list();

		}

		private void Condition_Checked(object sender, RoutedEventArgs e)
		{
			comboBox.ItemsSource = bl.get_contract_condition_list();
		}
		
		private void All_unChecked(object sender, RoutedEventArgs e)
		{
			All_Checked(this, e);

		}

		private void Condition_unChecked(object sender, RoutedEventArgs e)
		{
			All_Checked(this, e);
		}

		private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			condition = (ContractCondition)comboBox.SelectedItem;
			if (condition == ContractCondition.Contract_Signed)
			{
				dataGrid.ItemsSource = bl.get_contracts_by_condition((Contract c)=>(c.Signed));
			}
			if (condition == ContractCondition.Price_is_Hourly)
			{
				dataGrid.ItemsSource = bl.get_contracts_by_condition((Contract c) => (c.Price_Is_Hourly));
			}
			if (condition == ContractCondition.Price_is_Monthly)
			{
				dataGrid.ItemsSource = bl.get_contracts_by_condition((Contract c) => (!c.Price_Is_Hourly));
			}
			if (condition == ContractCondition.Introduction_Meeting_Happened)
			{
				dataGrid.ItemsSource = bl.get_contracts_by_condition((Contract c) => (c.Introduction_meeting));
			}
		}
	}
}
