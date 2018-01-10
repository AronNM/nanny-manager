using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
	public class Child
	{
		#region properties
		public int Id { get; set; }
		public int Mother_Id { get; set; }
		public string First_Name { get; set; }
		public DateTime Birth_Date { get; set; }
		public bool Special_Needs { get; set; }
		public string Needs { get; set; }
		//MORE Attributes
		#endregion
		public override string ToString()
		{
			return "ID: " + this.Id + "\nFirst Name: " + this.First_Name + "\nBirth day: " + this.Birth_Date.ToString("dd/MM/yyyy") + ((this.Special_Needs)? ("\nSpecial Needs: " + this.Needs) : "");
		}
	}
}
