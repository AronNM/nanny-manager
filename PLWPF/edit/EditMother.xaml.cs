using BE;
using BL;
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

namespace PLWPF.edit
{
    /// <summary>
    /// Interaction logic for EditMother.xaml
    /// </summary>
    public partial class EditMother : Window
    {
        IBL bl;
        Mother mother;
        public EditMother()
        {
            bl = factoryBL.get_bl();
            mother = new Mother();
            InitializeComponent();
            comboBox.ItemsSource = bl.get_mother_list();
            comboBox.DisplayMemberPath = "Id";
            comboBox.SelectedValuePath = "Id";
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mother = (Mother)comboBox.SelectedItem;
            this.IdBox.Text = mother.Id.ToString();
            this.FIrstNameBox.Text = mother.First_Name;
            this.LastNameBox.Text = mother.Family_Name;
            this.AddressBox.Text = mother.Home_Address;
            this.SecondAddressBox.Text = mother.Second_Address;
            this.MaxTravelDistanceBox.Text = mother.Max_Travel_Distance.ToString();
            #region erase boxes
            this.SundayButton.IsChecked = false;
            this.MondayButton.IsChecked = false;
            this.TuesdayButton.IsChecked = false;
            this.WednesdayButton.IsChecked = false;
            this.ThursdayButton.IsChecked = false;
            this.FridayButton.IsChecked = false;
            this.Sundaystart.textBox.Clear();
            this.Sundaystart.textBox1.Clear();
            this.SundayEnd.textBox.Clear();
            this.SundayEnd.textBox1.Clear();
            this.MondayStart.textBox.Clear();
            this.MondayStart.textBox1.Clear();
            this.MondayEnd.textBox.Clear();
            this.MondayEnd.textBox1.Clear();
            this.TuesdayStart.textBox.Clear();
            this.TuesdayStart.textBox1.Clear();
            this.TuesdayEnd.textBox.Clear();
            this.TuesdayEnd.textBox1.Clear();
            this.WednesdayStart.textBox.Clear();
            this.WednesdayStart.textBox1.Clear();
            this.WednesdayEnd.textBox.Clear();
            this.WednesdayEnd.textBox1.Clear();
            this.ThursdayStart.textBox.Clear();
            this.ThursdayStart.textBox1.Clear();
            this.ThursdayEnd.textBox.Clear();
            this.ThursdayEnd.textBox1.Clear();
            this.FridayStart.textBox.Clear();
            this.FridayStart.textBox1.Clear();
            this.FridayEnd.textBox.Clear();
            this.FridayEnd.textBox1.Clear();

#endregion
            if (mother.Needs_On_Day[0])
            {
                this.SundayButton.IsChecked = true;
                this.Sundaystart.textBox.Text = mother.Needs_Hours[0, 0].Hours.ToString();
                this.Sundaystart.textBox1.Text = mother.Needs_Hours[0, 0].Minutes.ToString();
                this.SundayEnd.textBox.Text = mother.Needs_Hours[1, 0].Hours.ToString();
                this.SundayEnd.textBox1.Text = mother.Needs_Hours[1, 0].Minutes.ToString();
            }
            if (mother.Needs_On_Day[1])
            {
                this.MondayButton.IsChecked = true;
                this.MondayStart.textBox.Text = mother.Needs_Hours[0, 1].Hours.ToString();
                this.MondayStart.textBox1.Text = mother.Needs_Hours[0, 1].Minutes.ToString();
                this.MondayEnd.textBox.Text = mother.Needs_Hours[1, 1].Hours.ToString();
                this.MondayEnd.textBox1.Text = mother.Needs_Hours[1, 1].Minutes.ToString();
            }
            if (mother.Needs_On_Day[2])
            {
                this.TuesdayButton.IsChecked = true;
                this.TuesdayStart.textBox.Text = mother.Needs_Hours[0, 2].Hours.ToString();
                this.TuesdayStart.textBox1.Text = mother.Needs_Hours[0, 2].Minutes.ToString();
                this.TuesdayEnd.textBox.Text = mother.Needs_Hours[1, 2].Hours.ToString();
                this.TuesdayEnd.textBox1.Text = mother.Needs_Hours[1, 2].Minutes.ToString();
            }
            if (mother.Needs_On_Day[3])
            {
                this.WednesdayButton.IsChecked = true;
                this.WednesdayStart.textBox.Text = mother.Needs_Hours[0, 3].Hours.ToString();
                this.WednesdayStart.textBox1.Text = mother.Needs_Hours[0, 3].Minutes.ToString();
                this.WednesdayEnd.textBox.Text = mother.Needs_Hours[1, 3].Hours.ToString();
                this.WednesdayEnd.textBox1.Text = mother.Needs_Hours[1, 3].Minutes.ToString();
            }
            if (mother.Needs_On_Day[4])
            {
                this.ThursdayButton.IsChecked = true;
                this.ThursdayStart.textBox.Text = mother.Needs_Hours[0, 4].Hours.ToString();
                this.ThursdayStart.textBox1.Text = mother.Needs_Hours[0, 4].Minutes.ToString();
                this.ThursdayEnd.textBox.Text = mother.Needs_Hours[1, 4].Hours.ToString();
                this.ThursdayEnd.textBox1.Text = mother.Needs_Hours[1, 4].Minutes.ToString();
            }
            if (mother.Needs_On_Day[5])
            {
                this.FridayButton.IsChecked = true;
                this.FridayStart.textBox.Text = mother.Needs_Hours[0, 5].Hours.ToString();
                this.FridayStart.textBox1.Text = mother.Needs_Hours[0, 5].Minutes.ToString();
                this.FridayEnd.textBox.Text = mother.Needs_Hours[1, 5].Hours.ToString();
                this.FridayEnd.textBox1.Text = mother.Needs_Hours[1, 5].Minutes.ToString();
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Mother temp = new Mother();
            temp.Id = int.Parse(this.IdBox.Text);
            temp.First_Name = this.FIrstNameBox.Text;
            temp.Family_Name = this.LastNameBox.Text;
            temp.Home_Address = this.AddressBox.Text;
            temp.Second_Address = this.SecondAddressBox.Text;
            temp.Max_Travel_Distance = int.Parse(this.MaxTravelDistanceBox.Text);

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

            mother = (Mother)comboBox.SelectedItem;
            bl.update_mother(mother.Id, temp);
            Close();
        }
    }
}
