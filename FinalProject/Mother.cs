using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
	public class Mother
	{
		#region properties
		public int Id { get; set; }
		public string Family_Name { get; set; }
		public string First_Name { get; set; }
		public string Telephone_Number { get; set; }
		public string Home_Address { get; set; }
		public string Second_Address { get; set; }
		public double Max_Travel_Distance { get; set; }
		public string Searching_Address { get; set; }
		public bool[] Needs_On_Day { get; set; }
		public TimeSpan[,] Needs_Hours { get; set; }
		public string Comments { get; set; }
        public Mother()
        {
            bool[] b = new bool[6];
            Needs_On_Day = b;
            TimeSpan[,] t = new TimeSpan[6, 2];
            Needs_Hours = t;
        }

        //MORE Attributes
        #endregion
        public override string ToString()
		{
            Console.WriteLine("");
            return "ID: " + this.Id + ", First name: " + this.First_Name + ", Family name: " + this.Family_Name + ", Telephone num:"
				+ this.Telephone_Number + "\nAddress: " + this.Home_Address + ", Max travel distance: " + this.Max_Travel_Distance + ", Comments: " + this.Comments
                +("\nSearching address: ") + this.Searching_Address
				+ "\nNeeds on the following days: " + ((this.Needs_On_Day[0]) ? "Sun, " : "") + ((this.Needs_On_Day[1]) ? "Mon, " : "") + ((this.Needs_On_Day[2]) ? "Tue, " : "") +
				((this.Needs_On_Day[3]) ? "Wed, " : "") + ((this.Needs_On_Day[4]) ? "Thur, " : "") + ((this.Needs_On_Day[5]) ? "Fri " : "");
		}
	}
}
