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

namespace PLWPF.edit
{
    /// <summary>
    /// Interaction logic for EditNanny.xaml
    /// </summary>
    public partial class EditNanny : Window
    {
        IBL bl;
        Nanny nanny;
        public EditNanny()
        {
            bl = factoryBL.get_bl();
            nanny = new Nanny(); 
            InitializeComponent();
            comboBox.ItemsSource = bl.get_nanny_list();
            comboBox.DisplayMemberPath = "Id";
            comboBox.SelectedValuePath = "Id";
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nanny = (Nanny)comboBox.SelectedItem;
            this.AddressBox.Text = nanny.Address;
            this.BirthDayBox.Text = nanny.Birth_Date.ToString();
            this.ExperienceYearsBox.Text = nanny.Experience_Years.ToString();
            this.IdBox.Text = nanny.Id.ToString();
            this.FirstNameBox.Text = nanny.First_Name;
            this.LastNameBox.Text = nanny.Family_Name;
            this.TelephoneBox.Text = nanny.Telephone_Number;
            this.FloorBox.Text = nanny.floor.ToString();
            this.NUmberChildrenBox.Text = nanny.Max_Children.ToString();
            this.MaxAgeBox.Text = nanny.Max_Child_Age.ToString();
            this.MinAgeBox.Text = nanny.Min_Child_Age.ToString();
            this.RecomendationBox.Text = nanny.Recommendations.ToString();
            this.Hourlyprice.IsChecked = false;
            this.MonthlyPrice.IsChecked = false;
            if (nanny.Hourly_Price_Exists)
            {
                this.Hourlyprice.IsChecked = true;
                price_label.Content = "The hourly price is:";
            }
            else
            {
                this.MonthlyPrice.IsChecked = true;
                price_label.Content = "The monthly price is:";
            }
            this.PriceBox.Text = nanny.Hourly_Price.ToString();
            this.Elevator_Yes.IsChecked = false;
            this.ElevatorNo.IsChecked = false;
            if (nanny.Elevator_Exists)
            {
                this.Elevator_Yes.IsChecked = true;
            }
            else
            {
                this.ElevatorNo.IsChecked = true;
            }
            hebrewbox.IsChecked = false;
            englishbox.IsChecked = false;
            russianbox.IsChecked = false;
            arabicbox.IsChecked = false;
            yidishbox.IsChecked = false;
            foreach(Language l in nanny.Lang)
            {
                if (l == BE.Language.HEBREW)
                {
                    hebrewbox.IsChecked = true;
                }
                if (l == BE.Language.ENGLISH)
                {
                    englishbox.IsChecked = true;
                }
                if (l == BE.Language.RUSSIAN)
                {
                    russianbox.IsChecked = true;

                }
                if (l == BE.Language.ARABIC)
                {
                    arabicbox.IsChecked = true;

                }
                if (l == BE.Language.YIDDISH)
                {
                    yidishbox.IsChecked = true;
                }
            }
            
            #region erase work days
            this.SundayButton.IsChecked = false;
            this.MondayButton.IsChecked = false;
            this.TuesdayButton.IsChecked = false;
            this.WednesdayButton.IsChecked = false;
            this.ThursdayButton.IsChecked = false;
            this.FridayButton.IsChecked = false;
            this.SundayStart.textBox.Clear();
            this.SundayStart.textBox1.Clear();
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
            if (nanny.Works_On_Day[0])
            {
                this.SundayButton.IsChecked = true;
                this.SundayStart.textBox.Text = nanny.Work_Hours[0, 0].Hours.ToString();
                this.SundayStart.textBox1.Text = nanny.Work_Hours[0, 0].Minutes.ToString();
                this.SundayEnd.textBox.Text = nanny.Work_Hours[1, 0].Hours.ToString();
                this.SundayEnd.textBox1.Text = nanny.Work_Hours[1, 0].Minutes.ToString();
            }
            if (nanny.Works_On_Day[1])
            {
                this.MondayButton.IsChecked = true;
                this.MondayStart.textBox.Text = nanny.Work_Hours[0, 1].Hours.ToString();
                this.MondayStart.textBox1.Text = nanny.Work_Hours[0, 1].Minutes.ToString();
                this.MondayEnd.textBox.Text = nanny.Work_Hours[1, 1].Hours.ToString();
                this.MondayEnd.textBox1.Text = nanny.Work_Hours[1, 1].Minutes.ToString();
            }
            if (nanny.Works_On_Day[2])
            {
                this.TuesdayButton.IsChecked = true;
                this.TuesdayStart.textBox.Text = nanny.Work_Hours[0, 2].Hours.ToString();
                this.TuesdayStart.textBox1.Text = nanny.Work_Hours[0, 2].Minutes.ToString();
                this.TuesdayEnd.textBox.Text = nanny.Work_Hours[1, 2].Hours.ToString();
                this.TuesdayEnd.textBox1.Text = nanny.Work_Hours[1, 2].Minutes.ToString();
            }
            if (nanny.Works_On_Day[3])
            {
                this.WednesdayButton.IsChecked = true;
                this.WednesdayStart.textBox.Text = nanny.Work_Hours[0, 3].Hours.ToString();
                this.WednesdayStart.textBox1.Text = nanny.Work_Hours[0, 3].Minutes.ToString();
                this.WednesdayEnd.textBox.Text = nanny.Work_Hours[1, 3].Hours.ToString();
                this.WednesdayEnd.textBox1.Text = nanny.Work_Hours[1, 3].Minutes.ToString();
            }
            if (nanny.Works_On_Day[4])
            {
                this.ThursdayButton.IsChecked = true;
                this.ThursdayStart.textBox.Text = nanny.Work_Hours[ 0,4].Hours.ToString();
                this.ThursdayStart.textBox1.Text = nanny.Work_Hours[0,4].Minutes.ToString();
                this.ThursdayEnd.textBox.Text = nanny.Work_Hours[1, 4].Hours.ToString();
                this.ThursdayEnd.textBox1.Text = nanny.Work_Hours[1, 4].Minutes.ToString();
            }
            if (nanny.Works_On_Day[5])
            {
                this.FridayButton.IsChecked = true;
                this.FridayStart.textBox.Text = nanny.Work_Hours[0,5].Hours.ToString();
                this.FridayStart.textBox1.Text = nanny.Work_Hours[0,5].Minutes.ToString();
                this.FridayEnd.textBox.Text = nanny.Work_Hours[1, 5].Hours.ToString();
                this.FridayEnd.textBox1.Text = nanny.Work_Hours[1, 5].Minutes.ToString();
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            Nanny temp = new Nanny();
            temp.Id = int.Parse(IdBox.Text);
            temp.First_Name = FirstNameBox.Text;
            temp.Family_Name = LastNameBox.Text;
            temp.Address = AddressBox.Text;
            temp.Birth_Date = Convert.ToDateTime(BirthDayBox.Text);
            temp.Telephone_Number = TelephoneBox.Text;
            if (ElevatorNo.IsPressed)
            {
                temp.Elevator_Exists = false;
            }
            else
            {
                temp.Elevator_Exists = true;
            }
            temp.Experience_Years = int.Parse(ExperienceYearsBox.Text);
            temp.floor = int.Parse(FloorBox.Text);
            if (Hourlyprice.IsChecked == true)
            {
                temp.Hourly_Price_Exists = true;
                temp.Hourly_Price = int.Parse(PriceBox.Text);
            }
            if (MonthlyPrice.IsChecked == true)
            {
                temp.Hourly_Price_Exists = false;
                temp.Monthly_Price = int.Parse(PriceBox.Text);
            }

            //temp.Lang = (Language)Enum.Parse(typeof(Language),comboBox.Text);
            temp.Max_Children = int.Parse(NUmberChildrenBox.Text);
            temp.Max_Child_Age = int.Parse(MaxAgeBox.Text);
            temp.Min_Child_Age = int.Parse(MinAgeBox.Text);
            temp.Recommendations = RecomendationBox.Text;

            if (SundayButton.IsChecked == true)
            {
                temp.Works_On_Day[0] = true;
                string time = SundayStart.textBox.Text + ":" + SundayStart.textBox1.Text;
                temp.Work_Hours[0, 0] = TimeSpan.Parse(time);
                time = SundayEnd.textBox.Text + ":" + SundayEnd.textBox1.Text;
                temp.Work_Hours[0, 1] = TimeSpan.Parse(time);
            }
            else temp.Works_On_Day[0] = false;
            if (MondayButton.IsChecked == true)
            {
                temp.Works_On_Day[1] = true;
                string time = MondayStart.textBox.Text + ":" + MondayStart.textBox1.Text;
                temp.Work_Hours[1, 0] = TimeSpan.Parse(time);
                time = MondayEnd.textBox.Text + ":" + MondayEnd.textBox1.Text;
                temp.Work_Hours[1, 1] = TimeSpan.Parse(time);
            }
            else temp.Works_On_Day[1] = false;
            if (TuesdayButton.IsChecked == true)
            {
                temp.Works_On_Day[2] = true;
                string time = TuesdayStart.textBox.Text + ":" + TuesdayStart.textBox1.Text;
                temp.Work_Hours[2, 0] = TimeSpan.Parse(time);
                time = TuesdayEnd.textBox.Text + ":" + TuesdayEnd.textBox1.Text;
                temp.Work_Hours[2, 1] = TimeSpan.Parse(time);
            }
            else temp.Works_On_Day[2] = false;
            if (WednesdayButton.IsChecked == true)
            {
                temp.Works_On_Day[3] = true;
                string time = WednesdayStart.textBox.Text + ":" + WednesdayStart.textBox1.Text;
                temp.Work_Hours[3, 0] = TimeSpan.Parse(time);
                time = WednesdayEnd.textBox.Text + ":" + WednesdayEnd.textBox1.Text;
                temp.Work_Hours[3, 1] = TimeSpan.Parse(time);
            }
            else temp.Works_On_Day[3] = false;
            if (ThursdayButton.IsChecked == true)
            {
                temp.Works_On_Day[4] = true;
                string time = ThursdayStart.textBox.Text + ":" + ThursdayStart.textBox1.Text;
                temp.Work_Hours[4, 0] = TimeSpan.Parse(time);
                time = ThursdayEnd.textBox.Text + ":" + ThursdayEnd.textBox1.Text;
                temp.Work_Hours[4, 1] = TimeSpan.Parse(time);
            }
            else temp.Works_On_Day[4] = false;
            if (FridayButton.IsChecked == true)
            {
                temp.Works_On_Day[5] = true;
                string time = FridayStart.textBox.Text + ":" + FridayStart.textBox1.Text;
                temp.Work_Hours[5, 0] = TimeSpan.Parse(time);
                time = FridayEnd.textBox.Text + ":" + FridayEnd.textBox1.Text;
                temp.Work_Hours[5, 1] = TimeSpan.Parse(time);
            }
            else temp.Works_On_Day[5] = false;

            if (hebrewbox.IsChecked == true)
            {
                temp.Lang.Add(BE.Language.HEBREW);
            }
            if (englishbox.IsChecked == true)
            {
                temp.Lang.Add(BE.Language.ENGLISH);
            }
            if (russianbox.IsChecked == true)
            {
                temp.Lang.Add(BE.Language.RUSSIAN);
            }
            if (arabicbox.IsChecked == true)
            {
                temp.Lang.Add(BE.Language.ARABIC);
            }
            if (yidishbox.IsChecked == true)
            {
                temp.Lang.Add(BE.Language.YIDDISH);
            }

            nanny = (Nanny)comboBox.SelectedItem;
            bl.update_nanny(nanny.Id, temp);
            Close();
        }

        private void monthly_clicked(object sender, RoutedEventArgs e)
        {

        }

        private void week_clicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
