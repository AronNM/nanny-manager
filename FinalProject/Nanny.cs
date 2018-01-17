using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
	
	public class Nanny
	{
		#region properties
		public int Id { get; set; }
		public string Family_Name { get; set; }
		public string First_Name { get; set; }
		public DateTime Birth_Date { get; set; }
		public string Telephone_Number { get; set; }
		public string Address { get; set; }
		public bool Elevator_Exists { get; set; }
		public int floor { get; set; }
		public int Experience_Years { get; set; }
		public int Max_Children { get; set; }
		public int Min_Child_Age { get; set; }
		public int Max_Child_Age { get; set; }
		public bool Hourly_Price_Exists { get; set; }
		public Double Hourly_Price { get; set; }
		public Double Monthly_Price { get; set; }
		public bool[] Works_On_Day { get; set; }
		public TimeSpan[,] Work_Hours { get; set; }
		public bool Vacation_Like_Tamat { get; set; }
		public string Recommendations { get; set; }
		//Custom Attributes
		public double Rating { get; set; }
		public List<Language> Lang { get; set; }
        public Nanny()
        {
            bool[] b = new bool[6];
            Lang = new List<Language>();
            Works_On_Day = b;
            TimeSpan[,] t = new TimeSpan[6, 2];
            Work_Hours = t;
        }
        #endregion
        public override string ToString()
		{
            Console.WriteLine("");
            return "ID: " + this.Id + "\nName: " + this.First_Name + " " + this.Family_Name + "\nBirth day: " + this.Birth_Date.ToString("dd/MM/yyyy") + "\nTelephone num: "
                + this.Telephone_Number + "\nAddress: " + this.Address + "\nFloor: " + this.floor + "\nExperience Years: " + this.Experience_Years + ((this.Elevator_Exists) ? "\nhas elevator" : "")
                + ((this.Vacation_Like_Tamat) ? "\nvacation like tamat" : "") + ((this.Hourly_Price_Exists) ? ("\nHourly Price " + this.Hourly_Price) : ("\nMonthly Price " + this.Monthly_Price))
                + "\nWorks on the following days: " + ((this.Works_On_Day[0]) ? "Sun\n" : "") + ((this.Works_On_Day[1]) ? "Mon\n" : "") + ((this.Works_On_Day[2]) ? "Tue\n" : "") +
                ((this.Works_On_Day[3]) ? "Wed\n" : "") + ((this.Works_On_Day[4]) ? "Thur\n" : "") + ((this.Works_On_Day[5]) ? "Fri " : "") +
                "\nRecommendations: " + this.Recommendations + ("\n Max children she can takes: ") + this.Max_Children+("  Max child age: ") + this.Max_Child_Age + ("  Min child age: " +this.Min_Child_Age);
		}
	}
}