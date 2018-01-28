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
            //we fill a combo box with all the existent Id mothers
            comboBox.ItemsSource = bl.get_mother_list();
            comboBox.DisplayMemberPath = "Id";
            comboBox.SelectedValuePath = "Id";
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//in order to brush the border of the wrong text box to red when a exception is catched, 
         // we must brush all the borders to black every time that the combobox is changed
            #region clear boarders
            IdBox.BorderBrush = Brushes.Black;
            MaxTravelDistanceBox.BorderBrush = Brushes.Black;
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
            // we create a new object based on the selected Id from the combo box, so we fill all the window controls
             // with this object properties
             mother = (Mother)comboBox.SelectedItem;
            this.IdBox.Text = mother.Id.ToString();
            this.FIrstNameBox.Text = mother.First_Name;
            this.LastNameBox.Text = mother.Family_Name;
            this.TelephoneBox.Text = mother.Telephone_Number;
            this.AddressBox.Text = mother.Home_Address;
            this.SecondAddressBox.Text = mother.Second_Address;
            this.MaxTravelDistanceBox.Text = mother.Max_Travel_Distance.ToString();
            //every time the combo box is changed we must clear all the the TimePickers and Week days checkbox
            //in order to show the accure data
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
                this.SundayEnd.textBox.Text = mother.Needs_Hours[0,1].Hours.ToString();
                this.SundayEnd.textBox1.Text = mother.Needs_Hours[0,1].Minutes.ToString();
            }
            if (mother.Needs_On_Day[1])
            {
                this.MondayButton.IsChecked = true;
                this.MondayStart.textBox.Text = mother.Needs_Hours[1,0].Hours.ToString();
                this.MondayStart.textBox1.Text = mother.Needs_Hours[1,0].Minutes.ToString();
                this.MondayEnd.textBox.Text = mother.Needs_Hours[1, 1].Hours.ToString();
                this.MondayEnd.textBox1.Text = mother.Needs_Hours[1, 1].Minutes.ToString();
            }
            if (mother.Needs_On_Day[2])
            {
                this.TuesdayButton.IsChecked = true;
                this.TuesdayStart.textBox.Text = mother.Needs_Hours[2,0].Hours.ToString();
                this.TuesdayStart.textBox1.Text = mother.Needs_Hours[2,0].Minutes.ToString();
                this.TuesdayEnd.textBox.Text = mother.Needs_Hours[2,1].Hours.ToString();
                this.TuesdayEnd.textBox1.Text = mother.Needs_Hours[2,1].Minutes.ToString();
            }
            if (mother.Needs_On_Day[3])
            {
                this.WednesdayButton.IsChecked = true;
                this.WednesdayStart.textBox.Text = mother.Needs_Hours[3,0].Hours.ToString();
                this.WednesdayStart.textBox1.Text = mother.Needs_Hours[3,0].Minutes.ToString();
                this.WednesdayEnd.textBox.Text = mother.Needs_Hours[3,1].Hours.ToString();
                this.WednesdayEnd.textBox1.Text = mother.Needs_Hours[3,1].Minutes.ToString();
            }
            if (mother.Needs_On_Day[4])
            {
                this.ThursdayButton.IsChecked = true;
                this.ThursdayStart.textBox.Text = mother.Needs_Hours[ 4,0].Hours.ToString();
                this.ThursdayStart.textBox1.Text = mother.Needs_Hours[4,0].Minutes.ToString();
                this.ThursdayEnd.textBox.Text = mother.Needs_Hours[4,1].Hours.ToString();
                this.ThursdayEnd.textBox1.Text = mother.Needs_Hours[4,1].Minutes.ToString();
            }
            if (mother.Needs_On_Day[5])
            {
                this.FridayButton.IsChecked = true;
                this.FridayStart.textBox.Text = mother.Needs_Hours[5,0].Hours.ToString();
                this.FridayStart.textBox1.Text = mother.Needs_Hours[5,0].Minutes.ToString();
                this.FridayEnd.textBox.Text = mother.Needs_Hours[5,1].Hours.ToString();
                this.FridayEnd.textBox1.Text = mother.Needs_Hours[ 5,1].Minutes.ToString();
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {//in order to brush the border of the wrong text box to red when a exception is catched, 
         // we must brush all the borders to black every time that we submit new data
            #region clear boarders
            IdBox.BorderBrush = Brushes.Black;
            MaxTravelDistanceBox.BorderBrush = Brushes.Black;
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
            Mother temp = new Mother();
            int num;
            TimeSpan result;
            try
            {//all the possibilities of enter data in the wrong type, as letters to string and so on, are covered here
                if (!int.TryParse(IdBox.Text, out num))
                {
                    IdBox.BorderBrush = Brushes.Red;
                    throw new Exception("You must enter a digit in the Id box.");

                }
                temp.Id = int.Parse(IdBox.Text);

                if (!int.TryParse(MaxTravelDistanceBox.Text, out num))
                {
                    MaxTravelDistanceBox.BorderBrush = Brushes.Red;
                    throw new Exception("You must enter a digit in the Max travel distance box.");

                }
                temp.Max_Travel_Distance = int.Parse(MaxTravelDistanceBox.Text);

                if (SundayButton.IsChecked == true)
                {//if the TimePicker Box was not filled, we fill it 00
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
                    temp.Needs_On_Day[0] = true;
                    string time = Sundaystart.textBox.Text + ":" + Sundaystart.textBox1.Text;
                    if (!TimeSpan.TryParse(Sundaystart.textBox.Text, out result) || !TimeSpan.TryParse(Sundaystart.textBox1.Text, out result))
                    {
                        Sundaystart.textBox.BorderBrush = Brushes.Red;
                        Sundaystart.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Needs_Hours[0, 0] = TimeSpan.Parse(time);
                    time = SundayEnd.textBox.Text + ":" + SundayEnd.textBox1.Text;
                    if (!TimeSpan.TryParse(SundayEnd.textBox.Text, out result) || !TimeSpan.TryParse(SundayEnd.textBox1.Text, out result))
                    {
                        SundayEnd.textBox.BorderBrush = Brushes.Red;
                        SundayEnd.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Needs_Hours[0, 1] = TimeSpan.Parse(time);
                }
                else temp.Needs_On_Day[0] = false;
                if (MondayButton.IsChecked == true)
                {//if the TimePicker Box was not filled, we fill it 00
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
                    temp.Needs_On_Day[1] = true;
                    string time = MondayStart.textBox.Text + ":" + MondayStart.textBox1.Text;
                    if (!TimeSpan.TryParse(MondayStart.textBox.Text, out result) || !TimeSpan.TryParse(MondayStart.textBox1.Text, out result))
                    {
                        MondayStart.textBox.BorderBrush = Brushes.Red;
                        MondayStart.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Needs_Hours[1, 0] = TimeSpan.Parse(time);
                    time = MondayEnd.textBox.Text + ":" + MondayEnd.textBox1.Text;
                    if (!TimeSpan.TryParse(MondayEnd.textBox.Text, out result) || !TimeSpan.TryParse(MondayEnd.textBox1.Text, out result))
                    {
                        MondayEnd.textBox.BorderBrush = Brushes.Red;
                        MondayEnd.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Needs_Hours[1, 1] = TimeSpan.Parse(time);
                }
                else temp.Needs_On_Day[1] = false;
                if (TuesdayButton.IsChecked == true)
                {//if the TimePicker Box was not filled, we fill it 00
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
                    temp.Needs_On_Day[2] = true;
                    string time = TuesdayStart.textBox.Text + ":" + TuesdayStart.textBox1.Text;
                    if (!TimeSpan.TryParse(TuesdayStart.textBox.Text, out result) || !TimeSpan.TryParse(TuesdayStart.textBox1.Text, out result))
                    {
                        TuesdayStart.textBox.BorderBrush = Brushes.Red;
                        TuesdayStart.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Needs_Hours[2, 0] = TimeSpan.Parse(time);
                    time = TuesdayEnd.textBox.Text + ":" + TuesdayEnd.textBox1.Text;
                    if (!TimeSpan.TryParse(TuesdayEnd.textBox.Text, out result) || !TimeSpan.TryParse(TuesdayEnd.textBox1.Text, out result))
                    {
                        TuesdayEnd.textBox.BorderBrush = Brushes.Red;
                        TuesdayEnd.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Needs_Hours[2, 1] = TimeSpan.Parse(time);
                }
                else temp.Needs_On_Day[2] = false;
                if (WednesdayButton.IsChecked == true)
                {//if the TimePicker Box was not filled, we fill it 00
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
                    temp.Needs_On_Day[3] = true;
                    string time = WednesdayStart.textBox.Text + ":" + WednesdayStart.textBox1.Text;
                    if (!TimeSpan.TryParse(WednesdayStart.textBox.Text, out result) || !TimeSpan.TryParse(WednesdayStart.textBox1.Text, out result))
                    {
                        WednesdayStart.textBox.BorderBrush = Brushes.Red;
                        WednesdayStart.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Needs_Hours[3, 0] = TimeSpan.Parse(time);
                    time = WednesdayEnd.textBox.Text + ":" + WednesdayEnd.textBox1.Text;
                    if (!TimeSpan.TryParse(WednesdayEnd.textBox.Text, out result) || !TimeSpan.TryParse(WednesdayEnd.textBox1.Text, out result))
                    {
                        WednesdayEnd.textBox.BorderBrush = Brushes.Red;
                        WednesdayEnd.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Needs_Hours[3, 1] = TimeSpan.Parse(time);
                }
                else temp.Needs_On_Day[3] = false;
                if (ThursdayButton.IsChecked == true)
                {//if the TimePicker Box was not filled, we fill it 00
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
                    temp.Needs_On_Day[4] = true;
                    string time = ThursdayStart.textBox.Text + ":" + ThursdayStart.textBox1.Text;
                    if (!TimeSpan.TryParse(ThursdayStart.textBox.Text, out result) || !TimeSpan.TryParse(ThursdayStart.textBox1.Text, out result))
                    {
                        ThursdayStart.textBox.BorderBrush = Brushes.Red;
                        ThursdayStart.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Needs_Hours[4, 0] = TimeSpan.Parse(time);
                    time = ThursdayEnd.textBox.Text + ":" + ThursdayEnd.textBox1.Text;
                    if (!TimeSpan.TryParse(ThursdayEnd.textBox.Text, out result) || !TimeSpan.TryParse(ThursdayEnd.textBox1.Text, out result))
                    {
                        ThursdayEnd.textBox.BorderBrush = Brushes.Red;
                        ThursdayEnd.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Needs_Hours[4, 1] = TimeSpan.Parse(time);
                }
                else temp.Needs_On_Day[4] = false;
                if (FridayButton.IsChecked == true)
                {//if the TimePicker Box was not filled, we fill it 00
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
                    temp.Needs_On_Day[5] = true;
                    string time = FridayStart.textBox.Text + ":" + FridayStart.textBox1.Text;
                    if (!TimeSpan.TryParse(FridayStart.textBox.Text, out result) || !TimeSpan.TryParse(FridayStart.textBox1.Text, out result))
                    {
                        FridayStart.textBox.BorderBrush = Brushes.Red;
                        FridayStart.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Needs_Hours[5, 0] = TimeSpan.Parse(time);
                    time = FridayEnd.textBox.Text + ":" + FridayEnd.textBox1.Text;
                    if (!TimeSpan.TryParse(FridayEnd.textBox.Text, out result) || !TimeSpan.TryParse(FridayEnd.textBox1.Text, out result))
                    {
                        FridayEnd.textBox.BorderBrush = Brushes.Red;
                        FridayEnd.textBox1.BorderBrush = Brushes.Red;
                        throw new Exception("You must enter a digit to the work hour box");

                    }
                    temp.Needs_Hours[5, 1] = TimeSpan.Parse(time);
                }
                else temp.Needs_On_Day[5] = false;

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
                return;
                
            }
            //these fields don't need exceptions
            temp.First_Name = this.FIrstNameBox.Text;
            temp.Family_Name = this.LastNameBox.Text;
            temp.Home_Address = this.AddressBox.Text;
            temp.Second_Address = this.SecondAddressBox.Text;
            temp.Telephone_Number = this.TelephoneBox.Text;
            //we create a new object with the data we collect from the window controls, after the updates
            mother = (Mother)comboBox.SelectedItem;
            try
            {//we send the new object to the BL
                bl.update_mother(temp, mother.Id);
                Close();
            }
            catch (Exception ex)
            {//catches the Exceptions that cames from the other layers
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
