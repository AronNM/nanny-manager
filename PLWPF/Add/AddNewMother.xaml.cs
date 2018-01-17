using BL;
using BE;
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

namespace PLWPF.Add
{
	/// <summary>
	/// Interaction logic for AddNewMother.xaml
	/// </summary>
	public partial class AddNewMother : Window
	{
        IBL bl;
        public AddNewMother()
		{
            bl = factoryBL.get_bl();
            InitializeComponent();
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Mother temp = new Mother();
            temp.Id = int.Parse(IdBox.Text);
            temp.First_Name = FIrstNameBox.Text;
            temp.Family_Name = LastNameBox.Text;
            temp.Home_Address = AddressBox.Text;
            temp.Second_Address = SecondAddressBox.Text;
            temp.Max_Travel_Distance = int.Parse(MaxTravelDistanceBox.Text);

            if (SundayButton.IsChecked == true)
            {
                temp.Needs_On_Day[0] = true;
                string time = Sundaystart.textBox.Text + ":" + Sundaystart.textBox1.Text;
                temp.Needs_Hours[0, 0] = TimeSpan.Parse(time);
                time = SundayEnd.textBox.Text + ":" + SundayEnd.textBox1.Text;
                temp.Needs_Hours[0, 1] = TimeSpan.Parse(time);
            }
            else temp.Needs_On_Day[0] = false;
            if (MondayButton.IsChecked == true)
            {
                temp.Needs_On_Day[1] = true;
                string time = MondayStart.textBox.Text + ":" + MondayStart.textBox1.Text;
                temp.Needs_Hours[1, 0] = TimeSpan.Parse(time);
                time = MondayEnd.textBox.Text + ":" + MondayEnd.textBox1.Text;
                temp.Needs_Hours[1, 1] = TimeSpan.Parse(time);
            }
            else temp.Needs_On_Day[1] = false;
            if (TuesdayButton.IsChecked == true)
            {
                temp.Needs_On_Day[2] = true;
                string time = TuesdayStart.textBox.Text + ":" + TuesdayStart.textBox1.Text;
                temp.Needs_Hours[2, 0] = TimeSpan.Parse(time);
                time = TuesdayEnd.textBox.Text + ":" + TuesdayEnd.textBox1.Text;
                temp.Needs_Hours[2, 1] = TimeSpan.Parse(time);
            }
            else temp.Needs_On_Day[2] = false;
            if (WednesdayButton.IsChecked == true)
            {
                temp.Needs_On_Day[3] = true;
                string time = WednesdayStart.textBox.Text + ":" + WednesdayStart.textBox1.Text;
                temp.Needs_Hours[3, 0] = TimeSpan.Parse(time);
                time = WednesdayEnd.textBox.Text + ":" + WednesdayEnd.textBox1.Text;
                temp.Needs_Hours[3, 1] = TimeSpan.Parse(time);
            }
            else temp.Needs_On_Day[3] = false;
            if (ThursdayButton.IsChecked == true)
            {
                temp.Needs_On_Day[4] = true;
                string time = ThursdayStart.textBox.Text + ":" + ThursdayStart.textBox1.Text;
                temp.Needs_Hours[4, 0] = TimeSpan.Parse(time);
                time = ThursdayEnd.textBox.Text + ":" + ThursdayEnd.textBox1.Text;
                temp.Needs_Hours[4, 1] = TimeSpan.Parse(time);
            }
            else temp.Needs_On_Day[4] = false;
            if (FridayButton.IsChecked == true)
            {
                temp.Needs_On_Day[5] = true;
                string time = FridayStart.textBox.Text + ":" + FridayStart.textBox1.Text;
                temp.Needs_Hours[5, 0] = TimeSpan.Parse(time);
                time = FridayEnd.textBox.Text + ":" + FridayEnd.textBox1.Text;
                temp.Needs_Hours[5, 1] = TimeSpan.Parse(time);
            }
            else temp.Needs_On_Day[5] = false;

            bl.add_mother(temp);
        }
    }
}
