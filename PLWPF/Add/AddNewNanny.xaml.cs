using BE;
using BL;
using PLWPF.windows;
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
            
            

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            #region clear boarders
            IdBox.BorderBrush = Brushes.Black;
            FloorBox.BorderBrush = Brushes.Black;
            NUmberChildrenBox.BorderBrush = Brushes.Black;
            ExperienceYearsBox.BorderBrush = Brushes.Black;
            BirthDayBox.BorderBrush = Brushes.Black;
            MaxAgeBox.BorderBrush = Brushes.Black;
            MinAgeBox.BorderBrush = Brushes.Black;
            PriceBox.BorderBrush = Brushes.Black;
            Sundaystart.textBox.BorderBrush = Brushes.Black;
            Sundaystart.textBox1.BorderBrush = Brushes.Black;
            SundayEnd.textBox.BorderBrush = Brushes.Black;
            SundayEnd.textBox1.BorderBrush = Brushes.Black;
            MondayStart.textBox.BorderBrush = Brushes.Black;
            MondayStart.textBox1.BorderBrush = Brushes.Black;
            MondayEnd.textBox.BorderBrush = Brushes.Black;
            MondayEnd.textBox1.BorderBrush = Brushes.Black;
            TuesdayStart.textBox.BorderBrush = Brushes.Black;
            TuesdayStart.textBox1.BorderBrush = Brushes.Black;
            TuesdayEnd.textBox.BorderBrush = Brushes.Black;
            TuesdayEnd.textBox1.BorderBrush = Brushes.Black;
            WednesdayStart.textBox.BorderBrush = Brushes.Black;
            WednesdayStart.textBox1.BorderBrush = Brushes.Black;
            WednesdayEnd.textBox.BorderBrush = Brushes.Black;
            WednesdayEnd.textBox1.BorderBrush = Brushes.Black;
            ThursdayStart.textBox.BorderBrush = Brushes.Black;
            ThursdayStart.textBox1.BorderBrush = Brushes.Black;
            ThursdayEnd.textBox.BorderBrush = Brushes.Black;
            ThursdayEnd.textBox1.BorderBrush = Brushes.Black;
            FridayStart.textBox.BorderBrush = Brushes.Black;
            FridayStart.textBox1.BorderBrush = Brushes.Black;
            FridayEnd.textBox.BorderBrush = Brushes.Black;
            FridayEnd.textBox1.BorderBrush = Brushes.Black;
            #endregion
            Nanny temp = new Nanny();
            int num;
            TimeSpan result;
            try
            {
                if(!int.TryParse(IdBox.Text,out num))
                {
                    IdBox.BorderBrush = Brushes.Red;
                    throw new Exception("You must enter a digit in the Id box.");
                   
                }
                temp.Id = int.Parse(IdBox.Text);
                temp.Birth_Date = Convert.ToDateTime(BirthDayBox.Text);

                if (!int.TryParse(ExperienceYearsBox.Text, out num))
                {
                    ExperienceYearsBox.BorderBrush = Brushes.Red;
                    throw new Exception("You must enter a digit in the Experience years box.");
                }
                temp.Experience_Years = int.Parse(ExperienceYearsBox.Text);

                if (!int.TryParse(FloorBox.Text, out num))
                {
                    FloorBox.BorderBrush = Brushes.Red;
                    throw new Exception("You must enter a digit in the Floor box.");
                }
                temp.floor = int.Parse(FloorBox.Text);

                if (!int.TryParse(NUmberChildrenBox.Text, out num))
                {
                    NUmberChildrenBox.BorderBrush = Brushes.Red;
                    throw new Exception("You must enter a digit in the Number of children box.");
                }
                temp.Max_Children = int.Parse(NUmberChildrenBox.Text);

                if (!int.TryParse(MaxAgeBox.Text, out num))
                {
                    MaxAgeBox.BorderBrush = Brushes.Red;
                    throw new Exception("You must enter a digit in the Max age box.");
                }
                temp.Max_Child_Age = int.Parse(MaxAgeBox.Text);

                if (!int.TryParse(MinAgeBox.Text, out num))
                {
                    MinAgeBox.BorderBrush = Brushes.Red;
                    throw new Exception("You must enter a digit in the Min age box.");
                }
                temp.Min_Child_Age = int.Parse(MinAgeBox.Text);


                if (!int.TryParse(PriceBox.Text, out num))
                {
                    PriceBox.BorderBrush = Brushes.Red;
                    throw new Exception("You must enter a digit in the Price box.");
                }
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

                if (SundayButton.IsChecked == true)
                {
                    if (Sundaystart.textBox.Text == "")
                    {
                        Sundaystart.textBox.Text = "00";
                    }
                    if (Sundaystart.textBox1.Text == "")
                    {
                        Sundaystart.textBox1.Text = "00";
                    }
                    if (SundayEnd.textBox.Text == "")
                    {
                        SundayEnd.textBox.Text = "00";
                    }
                    if (SundayEnd.textBox1.Text == "")
                    {
                        SundayEnd.textBox1.Text = "00";
                    }

                    temp.Works_On_Day[0] = true;
                    string time = Sundaystart.textBox.Text + ":" + Sundaystart.textBox1.Text;
                    if (!TimeSpan.TryParse(Sundaystart.textBox.Text,out result)|| !TimeSpan.TryParse(Sundaystart.textBox1.Text, out result))
                    {
                        Sundaystart.textBox.BorderBrush = Brushes.Red;
                        Sundaystart.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Work_Hours[0, 0] = TimeSpan.Parse(time);
                    time = SundayEnd.textBox.Text + ":" + SundayEnd.textBox1.Text;
                    if (!TimeSpan.TryParse(SundayEnd.textBox.Text, out result) || !TimeSpan.TryParse(SundayEnd.textBox1.Text, out result))
                    {
                        SundayEnd.textBox.BorderBrush = Brushes.Red;
                        SundayEnd.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Work_Hours[0, 1] = TimeSpan.Parse(time);
                }
                else temp.Works_On_Day[0] = false;
                if (MondayButton.IsChecked == true)
                {
                    if (MondayStart.textBox.Text == "")
                    {
                        MondayStart.textBox.Text = "00";
                    }
                    if (MondayEnd.textBox.Text == "")
                    {
                        MondayEnd.textBox.Text = "00";
                    }
                    if (MondayStart.textBox1.Text == "")
                    {
                        MondayStart.textBox1.Text = "00";
                    }
                    if (MondayEnd.textBox1.Text == "")
                    {
                        MondayEnd.textBox1.Text = "00";
                    }
                    temp.Works_On_Day[1] = true;
                    string time = MondayStart.textBox.Text + ":" + MondayStart.textBox1.Text;
                    if (!TimeSpan.TryParse(MondayStart.textBox.Text, out result) || !TimeSpan.TryParse(MondayStart.textBox1.Text, out result))
                    {
                        MondayStart.textBox.BorderBrush = Brushes.Red;
                        MondayStart.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");
                    }
                    temp.Work_Hours[1, 0] = TimeSpan.Parse(time);
                    time = MondayEnd.textBox.Text + ":" + MondayEnd.textBox1.Text;
                    if (!TimeSpan.TryParse(MondayEnd.textBox.Text, out result) || !TimeSpan.TryParse(MondayEnd.textBox1.Text, out result))
                    {
                        MondayEnd.textBox.BorderBrush = Brushes.Red;
                        MondayEnd.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Work_Hours[1, 1] = TimeSpan.Parse(time);
                }
                else temp.Works_On_Day[1] = false;
                if (TuesdayButton.IsChecked == true)
                {
                    if (TuesdayStart.textBox.Text == "")
                    {
                        TuesdayStart.textBox.Text = "00";
                    }
                    if (TuesdayEnd.textBox.Text == "")
                    {
                        TuesdayEnd.textBox.Text = "00";
                    }
                    if (TuesdayStart.textBox1.Text == "")
                    {
                        TuesdayStart.textBox1.Text = "00";
                    }
                    if (TuesdayEnd.textBox1.Text == "")
                    {
                        TuesdayEnd.textBox1.Text = "00";
                    }
                    temp.Works_On_Day[2] = true;
                    string time = TuesdayStart.textBox.Text + ":" + TuesdayStart.textBox1.Text;
                    if (!TimeSpan.TryParse(TuesdayStart.textBox.Text, out result) || !TimeSpan.TryParse(TuesdayStart.textBox1.Text, out result))
                    {
                        TuesdayStart.textBox.BorderBrush = Brushes.Red;
                        TuesdayStart.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Work_Hours[2, 0] = TimeSpan.Parse(time);
                    time = TuesdayEnd.textBox.Text + ":" + TuesdayEnd.textBox1.Text;
                    if (!TimeSpan.TryParse(TuesdayEnd.textBox.Text, out result) || !TimeSpan.TryParse(TuesdayEnd.textBox1.Text, out result))
                    {
                        TuesdayEnd.textBox.BorderBrush = Brushes.Red;
                        TuesdayEnd.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Work_Hours[2, 1] = TimeSpan.Parse(time);
                }
                else temp.Works_On_Day[2] = false;
                if (WednesdayButton.IsChecked == true)
                {
                    if (WednesdayStart.textBox.Text == "")
                    {
                        WednesdayStart.textBox.Text = "00";
                    }
                    if (WednesdayEnd.textBox.Text == "")
                    {
                        WednesdayEnd.textBox.Text = "00";
                    }
                    if (WednesdayStart.textBox1.Text == "")
                    {
                        WednesdayStart.textBox1.Text = "00";
                    }
                    if (WednesdayEnd.textBox1.Text == "")
                    {
                        WednesdayEnd.textBox1.Text = "00";
                    }
                    temp.Works_On_Day[3] = true;
                    string time = WednesdayStart.textBox.Text + ":" + WednesdayStart.textBox1.Text;
                    if (!TimeSpan.TryParse(WednesdayStart.textBox.Text, out result) || !TimeSpan.TryParse(WednesdayStart.textBox1.Text, out result))
                    {
                        WednesdayStart.textBox.BorderBrush = Brushes.Red;
                        WednesdayStart.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Work_Hours[3, 0] = TimeSpan.Parse(time);
                    time = WednesdayEnd.textBox.Text + ":" + WednesdayEnd.textBox1.Text;
                    if (!TimeSpan.TryParse(WednesdayEnd.textBox.Text, out result) || !TimeSpan.TryParse(WednesdayEnd.textBox1.Text, out result))
                    {
                        WednesdayEnd.textBox.BorderBrush = Brushes.Red;
                        WednesdayEnd.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Work_Hours[3, 1] = TimeSpan.Parse(time);
                }
                else temp.Works_On_Day[3] = false;
                if (ThursdayButton.IsChecked == true)
                {
                    if (ThursdayStart.textBox.Text == "")
                    {
                        ThursdayStart.textBox.Text = "00";
                    }
                    if (ThursdayEnd.textBox.Text == "")
                    {
                        ThursdayEnd.textBox.Text = "00";
                    }
                    if (ThursdayStart.textBox1.Text == "")
                    {
                        ThursdayStart.textBox1.Text = "00";
                    }
                    if (ThursdayEnd.textBox1.Text == "")
                    {
                        ThursdayEnd.textBox1.Text = "00";
                    }
                    temp.Works_On_Day[4] = true;
                    string time = ThursdayStart.textBox.Text + ":" + ThursdayStart.textBox1.Text;
                    if (!TimeSpan.TryParse(ThursdayStart.textBox.Text, out result) || !TimeSpan.TryParse(ThursdayStart.textBox1.Text, out result))
                    {
                        ThursdayStart.textBox.BorderBrush = Brushes.Red;
                        ThursdayStart.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Work_Hours[4, 0] = TimeSpan.Parse(time);
                    time = ThursdayEnd.textBox.Text + ":" + ThursdayEnd.textBox1.Text;
                    if (!TimeSpan.TryParse(ThursdayEnd.textBox.Text, out result) || !TimeSpan.TryParse(ThursdayEnd.textBox1.Text, out result))
                    {
                        ThursdayEnd.textBox.BorderBrush = Brushes.Red;
                        ThursdayEnd.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Work_Hours[4, 1] = TimeSpan.Parse(time);
                }
                else temp.Works_On_Day[4] = false;
                if (FridayButton.IsChecked == true)
                {
                    if (FridayStart.textBox.Text == "")
                    {
                        FridayStart.textBox.Text = "00";
                    }
                    if (FridayEnd.textBox.Text == "")
                    {
                        FridayEnd.textBox.Text = "00";
                    }
                    if (FridayStart.textBox1.Text == "")
                    {
                        FridayStart.textBox1.Text = "00";
                    }
                    if (FridayEnd.textBox1.Text == "")
                    {
                        FridayEnd.textBox1.Text = "00";
                    }
                    temp.Works_On_Day[5] = true;
                    string time = FridayStart.textBox.Text + ":" + FridayStart.textBox1.Text;
                    if (!TimeSpan.TryParse(FridayStart.textBox.Text, out result) || !TimeSpan.TryParse(FridayStart.textBox1.Text, out result))
                    {
                        FridayStart.textBox.BorderBrush = Brushes.Red;
                        FridayStart.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Work_Hours[5, 0] = TimeSpan.Parse(time);
                    time = FridayEnd.textBox.Text + ":" + FridayEnd.textBox1.Text;
                    if (!TimeSpan.TryParse(FridayEnd.textBox.Text, out result) || !TimeSpan.TryParse(FridayEnd.textBox1.Text, out result))
                    {
                        FridayEnd.textBox.BorderBrush = Brushes.Red;
                        FridayEnd.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Work_Hours[5, 1] = TimeSpan.Parse(time);
                }
                else temp.Works_On_Day[5] = false;
            }
            catch(Exception ex)
            {
                //ExceptionWindow win = new ExceptionWindow();

                //if (ex.Message == "Input string was not in a correct format.")
                //{
                //    //win.Exception_label.Content = "You must enter a digit to Id";
                //    // win.Exception_label.Content = ex.Message;
                //    MessageBox.Show(ex.Message);
                //}
                
                if (ex.Message == "String was not recognized as a valid DateTime.")
                {
                    BirthDayBox.BorderBrush = Brushes.Red;
                    MessageBox.Show("You must choose a date in the calender");
                    return;
                    
                }
                
                MessageBox.Show(ex.Message);
                return;
            }


            
                
                
                temp.First_Name = FirstNameBox.Text;
                temp.Family_Name = LastNameBox.Text;
                temp.Address = AddressBox.Text;
                
                temp.Telephone_Number = TelephoneBox.Text;
                if (ElevatorNo.IsPressed)
                {
                    temp.Elevator_Exists = false;
                }
                else
                {
                    temp.Elevator_Exists = true;
                }
                
                

                //temp.Lang = (Language)Enum.Parse(typeof(Language),comboBox.Text);
                
                temp.Recommendations = RecomendationBox.Text;


                

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
            try
            {
                bl.add_nanny(temp);
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           



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
