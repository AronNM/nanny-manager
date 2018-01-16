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

namespace PLWPF.Add
{
    /// <summary>
    /// Interaction logic for AddNewNanny.xaml
    /// </summary>
   
    public partial class AddNewNanny : Window
    {
        IBL bl;

        public AddNewNanny()
        {
            InitializeComponent();
            bl = factoryBL.get_bl();
            for (int i = 0; i < 5; i++)
            {
                ComboBoxItem newItem = new ComboBoxItem();
                BE.Language l = (BE.Language)i;
                newItem.Content = l.ToString();
  
                comboBox.Items.Add(newItem);


            }
            
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

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
            if (Hourlyprice.IsChecked==true)
            {
                temp.Hourly_Price_Exists = true;
                temp.Hourly_Price = int.Parse(PriceBox.Text);
            }
            if (MonthlyPrice.IsChecked == true)
            {
                temp.Hourly_Price_Exists = false;
                temp.Monthly_Price = int.Parse(PriceBox.Text);
            }
            
            temp.Lang = (Language)Enum.Parse(typeof(Language),comboBox.Text);
            temp.Max_Children = int.Parse(NUmberChildrenBox.Text);
            temp.Max_Child_Age = int.Parse(MaxAgeBox.Text);
            temp.Min_Child_Age = int.Parse(MinAgeBox.Text);
            temp.Recommendations = RecomendationBox.Text;
            
            if(SundayButton.IsChecked==true)
            {
                temp.Works_On_Day[0] = true;
                string time = Sundaystart.textBox.Text + ":" + Sundaystart.textBox1.Text;
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

            bl.add_nanny(temp);



        }

        

        private void week_clicked(object sender, RoutedEventArgs e)
        {
            price_label.Content = " The hourly price is:";
        }

        private void monthly_clicked(object sender, RoutedEventArgs e)
        {
           price_label.Content = " The monthly price is:";
        }
    }
}
