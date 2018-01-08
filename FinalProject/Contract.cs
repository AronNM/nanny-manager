using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
	public class Contract
	{
		#region properties
		public int Number { get; set; }
		public int Nanny_Id { get; set; }
		public int Child_Id { get; set; }
		public int Mother_Id { get; set; }
		public bool Introduction_meeting { get; set; }
		public bool Signed { get; set; }
		public Double Hourly_Price { get; set; }
		public Double Monthly_Price { get; set; }
		public bool Price_Is_Hourly { get; set; }
		public DateTime Starts { get; set; }
		public DateTime Ends { get; set; }
		//MORE Attributes
		#endregion
		public override string ToString()
		{
			return "Contract #" + this.Number + ", Nanny ID: " + this.Nanny_Id + ", Child ID: " + this.Child_Id + ", Mother_Id: " + this.Mother_Id + ((this.Signed) ? ", Has Been signed " : ", Hasn't Been signed")
				+ ((this.Price_Is_Hourly) ? (", Hourly Price " + this.Hourly_Price) : (", Monthly Price " + this.Monthly_Price))
				+ ", Start Date: " + this.Starts.Date.ToString("dd/MM/yyyy") + ", End Date: " + this.Ends.Date.ToString("dd/MM/yyyy");
		}
	}
}
