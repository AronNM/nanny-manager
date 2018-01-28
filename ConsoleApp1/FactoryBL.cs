using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
	/// <summary>
	/// Factory design method with function to return current BL instance. If no instance exists the function creates new instance
	/// </summary>
	public class factoryBL
	{

		static BL_imp FactoryBl = null;

		/// <summary>
		/// function which returns current BL instance. If no instance exists creates new instance
		/// </summary>
		/// <returns></returns>
		public static IBL get_bl()
		{
			if (FactoryBl == null)
			{
				FactoryBl = new BL_imp();
			 //   initialize(FactoryBl);      //function which initializes the instance with demo values

			}
			return FactoryBl;
		}

		/// <summary>
		/// function which initializes the instance with demo values
		/// Only used on the first run of the program as after that values are stored in the xml files
		/// </summary>
		/// <param name="bl"></param>
		public static void initialize(BL_imp bl)
		{
            #region nanny 1 definition
            Nanny n1 = new Nanny();
            n1.Address = "21, havaad haleumi, jerusalem, israel";
            n1.First_Name = "Zelda P.";
            n1.Family_Name = "Tzudkevotsky";
            n1.Birth_Date = DateTime.Now.AddYears(-23);
            n1.Elevator_Exists = true;
            n1.Id = 234234564;
            n1.Hourly_Price = 23;
            n1.Hourly_Price_Exists = true;
            n1.Max_Children = 20;
            n1.Max_Child_Age = 18;
            n1.Min_Child_Age = 5;
            n1.Vacation_Like_Tamat = true;
            n1.Works_On_Day = new bool[] { true, true, true, true, true, false, false };
            n1.Work_Hours = new TimeSpan[6,2] { { new TimeSpan(8, 0, 0), new TimeSpan(15,0,0) }, { new TimeSpan(8, 0, 0), new TimeSpan(15,0,0)}, { new TimeSpan(8,0,0),new TimeSpan(15,0,0) }
                                                ,{ new TimeSpan(8, 0, 0), new TimeSpan(15,0,0) }, {  new TimeSpan(8, 0, 0), new TimeSpan(15,0,0) }, { new TimeSpan(8,0,0), new TimeSpan(15,0,0)} };
            n1.Experience_Years = 1;
            n1.Lang.Add(Language.YIDDISH);
            n1.Recommendations = "Zelda is the Besat! We love her! from Pesha";
            n1.Telephone_Number = "058-432-1109";
            n1.Rating = 5;
            bl.add_nanny(n1);
            #endregion

            #region nanny 2 definition
            Nanny n2 = new Nanny();
            n2.Address = "27, Hapisga St., jerusalem, israel";
            n2.First_Name = "Fruma Tova";
            n2.Family_Name = "Bombalovski";
            n2.Birth_Date = DateTime.Now.AddYears(-19).AddMonths(-5).AddDays(19);
            n2.Elevator_Exists = true;
            n2.Id = 312509871;
            n2.Hourly_Price = 26;
            n2.Hourly_Price_Exists = true;
            n2.Monthly_Price = 1400;
            n2.Max_Children = 15;
            n2.Max_Child_Age = 12;
            n2.Min_Child_Age = 3;
            n2.Vacation_Like_Tamat = true;
            n2.Works_On_Day = new bool[] { false, true, true, true, true, true, false };
            n2.Work_Hours = new TimeSpan[6,2] { { new TimeSpan(8, 30, 0), new TimeSpan(14, 0, 0) }, { new TimeSpan(8, 30, 0), new TimeSpan(14, 0, 0) }, { new TimeSpan(8, 30, 0), new TimeSpan(14, 0, 0) },
                                                { new TimeSpan(8, 30, 0), new TimeSpan(14, 0, 0) },{ new TimeSpan(8, 30, 0), new TimeSpan(14, 0, 0) },{ new TimeSpan(8, 30, 0), new TimeSpan(14, 0, 0) }};
            n2.Experience_Years = 3;
            n2.Lang.Add(Language.YIDDISH);
            n2.Recommendations = "Fruma Fruma , What we do without her! She is the #1 ganenet!";
            n2.Telephone_Number = "052-987-1908";
            n2.Rating = 4;
            bl.add_nanny(n2);
            #endregion

            #region nanny 3 definition
            Nanny n3 = new Nanny();
            n3.Address = "35, Nahal Dolev, Beit Shemesh, israel";
            n3.First_Name = "Tova";
            n3.Family_Name = "Cohen";
            n3.Birth_Date = DateTime.Now.AddYears(-52).AddDays(100);
            n3.Elevator_Exists = false;
            n3.Id = 112324543;
            n3.Hourly_Price = 32;
            n3.Monthly_Price = 1700;
            n3.Hourly_Price_Exists = true;
            n3.Max_Children = 26;
            n3.Max_Child_Age = 24;
            n3.Min_Child_Age = 10;
            n3.Vacation_Like_Tamat = false;
            n3.Works_On_Day = new bool[] { true, true, true, true, true, true, false };
            n3.Work_Hours = new TimeSpan[6,2] { { new TimeSpan(7, 15, 0), new TimeSpan(17, 0, 0) }, { new TimeSpan(7, 15, 0), new TimeSpan(17, 0, 0) } , { new TimeSpan(7, 15, 0), new TimeSpan(17, 0, 0) } , { new TimeSpan(7, 15, 0), new TimeSpan(17, 0, 0) } , { new TimeSpan(7, 15, 0), new TimeSpan(17, 0, 0) } , { new TimeSpan(7, 15, 0), new TimeSpan(17, 0, 0) } };
            n3.Experience_Years = 31;
            n3.Lang.Add(Language.HEBREW);
            n3.Recommendations = "Tova was my grandmothers ganenet, my ganent and now my daughters ganenet. She loves the children like her own. We highly recommend her!";
            n3.Telephone_Number = "02-995-1128";
            n3.Rating = 4.7;
            bl.add_nanny(n3);
            #endregion

            #region child 1 definition
            Child c1 = new Child();
			c1.Birth_Date = DateTime.Now.AddDays(-450);
			c1.First_Name = "Moishy";
			c1.Id = 311478632;
			c1.Mother_Id = 334151678;
			c1.Special_Needs = true;
			c1.Needs = "Is being toilet trained. needs special care!";
			bl.add_child(c1);
			#endregion

			#region child 2 definition
			Child c2 = new Child();
			c2.Birth_Date = DateTime.Now.AddDays(-250);
			c2.First_Name = "Shmuley";
			c2.Id = 313486930;
			c2.Mother_Id = 334151678;
			c2.Special_Needs = true;
			c2.Needs = "Is jeleous of his brother who is being toilet trained. needs special care!";
			bl.add_child(c2);
			#endregion

			#region child 3 definition
			Child c3 = new Child();
			c3.Birth_Date = DateTime.Now.AddDays(-292);
			c3.First_Name = "Hassan";
			c3.Id = 345908476;
			c3.Mother_Id = 245674839;
			c3.Special_Needs = false;
			bl.add_child(c3);
			#endregion

			#region child 4 definition
			Child c4 = new Child();
			c4.Birth_Date = DateTime.Now.AddDays(-387);
			c4.First_Name = "Dora";
			c4.Id = 345987610;
			c4.Mother_Id = 142365876;
			c4.Special_Needs = false;
			bl.add_child(c4);
			#endregion

			#region child 5 definition
			Child c5 = new Child();
			c5.Birth_Date = DateTime.Now.AddDays(-123);
			c5.First_Name = "Shirli";
			c5.Id = 388765612;
			c5.Mother_Id = 339876879;
			c5.Special_Needs = true;
			c5.Needs = "Shirli is elergic to penuts";
			bl.add_child(c5);
			#endregion

			#region child 6 definition
			Child c6 = new Child();
			c6.Birth_Date = DateTime.Now.AddDays(-388);
			c6.First_Name = "Sasha";
			c6.Id = 389765429;
			c6.Mother_Id = 339876879;
			c6.Special_Needs = false;
			bl.add_child(c6);
			#endregion

			#region child 7 definition
			Child c7 = new Child();
			c7.Birth_Date = DateTime.Now.AddDays(-448);
			c7.First_Name = "Problematic_kid";
			c7.Id = 338490123;
			c7.Mother_Id = 123412341;
			c7.Special_Needs = true;
			c7.Needs = "I need to be watched all day!";
			bl.add_child(c7);
			#endregion

			#region mother 1 definition
			Mother m1 = new Mother();
			m1.Id = 334151678;
			m1.First_Name = "Sarah";
			m1.Family_Name = "Levi";
			m1.Home_Address = "Nahal Refaim 38, Beit Shemesh, Israel";
			m1.Max_Travel_Distance = 10;
			m1.Needs_On_Day = new bool[] { true, true, true, true, true, false, false };
			m1.Needs_Hours = new TimeSpan[6,2] { { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) } };
			m1.Searching_Address = "Nahal Refaim 38, Beit Shemesh, Israel";
			m1.Telephone_Number = "02-991-3245";
			bl.add_mother(m1);
			#endregion

			#region mother 2 definition
			Mother m2 = new Mother();
			m2.Id = 245674839;
			m2.First_Name = "Shrik";
			m2.Family_Name = "Abu Hamda";
			m2.Home_Address = "21 Yafo St., Jerusalem, Israel";
			m2.Max_Travel_Distance = 100;
			m2.Needs_On_Day = new bool[] { false, false, true, true, false, false, false };
			m2.Needs_Hours = new TimeSpan[6,2] { { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) } };
			m2.Searching_Address = "21 Yafo St., Jerusalem, Israel";
			m2.Telephone_Number = "055-253-9487";
			bl.add_mother(m2);
			#endregion

			#region mother 3 definition
			Mother m3 = new Mother();
			m3.Id = 142365876;
			m3.First_Name = "Tohar";
			m3.Family_Name = "Mizrachi";
			m3.Home_Address = "10 Beit Hadfus, Jerusalem, Israel";
			m3.Max_Travel_Distance = 50;
			m3.Needs_On_Day = new bool[] { false, true, true, true, true, true, false };
			m3.Needs_Hours = new TimeSpan[ 6,2] { { new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0) } };
			m3.Searching_Address = "10 King George, Jerusalem, Israel";
			m3.Telephone_Number = "02-553-3981";
			bl.add_mother(m3);
			#endregion

			#region mother 4 definition
			Mother m4 = new Mother();
			m4.Id = 123412341;
			m4.First_Name = "Shula";
			m4.Family_Name = "Zaken";
			m4.Home_Address = "22 Kanfei Nesharim, Jerusalem, Israel";
			m4.Max_Travel_Distance = 100;
			m4.Needs_On_Day = new bool[] { true, true, true, true, true, true, true };
            m4.Needs_Hours = new TimeSpan[6, 2] { { new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 59) }, { new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 59) }, { new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 59) }, { new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 59) }, { new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 59) }, { new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 59) } };
			m4.Home_Address = "20 Malchei Yisrael, Jerusalem, Israel";
			m4.Telephone_Number = "02-544-9475";
			bl.add_mother(m4);
			#endregion

			#region mother 5 definition
			Mother m5 = new Mother();
			m5.Id = 339876879;
			m5.First_Name = "Nafta";
			m5.Family_Name = "Shluk";
			m5.Home_Address = "20 Malchei Yisrael, Jerusalem, Israel";
			m5.Max_Travel_Distance = 30;
			m5.Needs_On_Day = new bool[] { true, true, true, true, true, false, false };
			m5.Needs_Hours = new TimeSpan[6,2] { { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) }, { new TimeSpan(8, 0, 0), new TimeSpan(15, 0, 0) } };
			m5.Home_Address = "20 Malchei Yisrael, Jerusalem, Israel";
			m5.Telephone_Number = "02-543-0781";
			bl.add_mother(m5);
			#endregion

		}
	}
}
