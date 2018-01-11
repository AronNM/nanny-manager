using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
	public enum Language { ENGLISH, HEBREW, RUSSIAN, YIDDISH, ARABIC }
	public enum SortMotherBy { random, Id, LastName, MaxTravelDistance }
	public enum SortNannyBy { random, Id, LastName, floor, Experience_Years, Max_Children, Hourly_Price, Monthly_Price, Rating, Lang }
	public enum Week { Sunday=1, Monday=2, Tuesday=3, Wednesday=4,Thursday=5,Friday=6}
	public enum ContractCondition { Contract_Signed, Price_is_Hourly, Price_is_Monthly, Introduction_Meeting_Happened }

	public static class Consts
	{
		public const double Discount = 0.02;
		
	}


}