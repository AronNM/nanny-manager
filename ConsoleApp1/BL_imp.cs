﻿//this class implements the bl functions which access the dal layer. This class contains all the business logic and verifications
using System;
using System.Collections.Generic;
using System.Linq;
using DAL_final;
using BE;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using GoogleMapsApi;

namespace BL
{
	public class BL_imp : IBL
	{
		Dal_imp d = new Dal_imp();
		const int group_spliter = 5;    //defines spliting of groups in groupby distance between nanny and mother
		static int last_contract_number = 11111111;


		#region nanny fuctions
		public void add_nanny(Nanny n)
		{
			// Save today's date.
			var today = DateTime.Today;
			// Calculate the age.

			int age = today.Year - n.Birth_Date.Year;
			// Go back to the year the person was born in case of a leap year
			if (n.Birth_Date > today.AddYears(-age)) age--;

			if (age < 18)
			{
				throw new Exception(" Can't add under age nanny!");
			}
			else
			{
				d.add_nanny(n);
			}
		}
		public void delete_nanny(int id)
		{
			d.delete_nanny(id);
		}
		public void update_nanny(int i, int s, string s2)
		{
			d.update_nanny(i,s,s2);
		}
        public void update_nanny(int i, int s, bool[] s2, TimeSpan[,] t)
        {
            d.update_nanny(i, s, s2,t);
        }
        #endregion

        #region mother fuctions
        public void add_mother(Mother m)
		{
			d.add_mother(m);
		}
		public void delete_mother(int id)
		{
			d.delete_mother(id);
		}
		public void update_mother(int id, int attribute, string s)
		{
			d.update_mother(id,attribute,s);
		}
        public void update_mother(int id, int attribute, bool[] b,TimeSpan[,] t)
        {
            d.update_mother(id,attribute,b,t);
        }

        #endregion

        #region child fuctions
        public void add_child(Child c)
		{
			d.add_child(c);
		}
		public void delete_child(int id)
		{
			d.delete_child(id);
		}
		public void update_child(int id, int attribute, string s)
		{
            d.update_child(id, attribute, s);
		}
        public void update_child(int id, int attribute, string s, string s2)
        {
            d.update_child(id, attribute, s, s2);
        }
        #endregion

        #region contract fuctions
        public void add_contract(Contract c)
		{
			foreach (var child in d.get_child_list())   // find instance of the relevent child
			{
				if (c.Child_Id == child.Id)
				{
					foreach (var nanny in d.get_nanny_list())   // find instance of the relevent nanny
					{
						if (c.Nanny_Id == nanny.Id)
						{
							foreach (var mother in d.get_mother_list()) // find instance of the relevent mother
							{
								if (child.Mother_Id == mother.Id)
								{
									#region insert monthly price
									// calulate mounthly payment 
									if (!(c.Price_Is_Hourly))
									{
										c.Monthly_Price = nanny.Monthly_Price;
									}
									if (c.Price_Is_Hourly)
									{
										int weekly_hours = 0;
										for (int day = 0; day < 7; day++)
										{
											if (nanny.Works_On_Day[day])
											{
												weekly_hours += (nanny.Work_Hours[1, day] - nanny.Work_Hours[0, day]).Hours;
											}

										}
										c.Monthly_Price = 4 * weekly_hours * nanny.Hourly_Price;
									}
									#endregion

									#region give sibling discount
									int amount_of_siblings = 0;
									foreach (var cont in d.get_contract_list())
									{
										if (cont.Mother_Id == mother.Id)
										{
											amount_of_siblings++;
										}
									}
									c.Monthly_Price *= (1 - amount_of_siblings * 0.02);     // dicount for each sibling is 0.02

									#endregion

									#region verify nanny isn't full
									int amount_of_children_by_nanny = 0;
									foreach (var cont in d.get_contract_list())
									{
										if (cont.Nanny_Id ==nanny.Id)
										{
											amount_of_children_by_nanny++;
										}
									}
									if (amount_of_children_by_nanny >= nanny.Max_Children)
									{
										throw new Exception("Nanny id num " + nanny.Id + " is Full and can't take more kids!");
									}
									#endregion

									#region verify child age
									// Save today's date.
									var today = DateTime.Today;
									// Calculate the age and verify child is older than 3 months
									var age = today.Year - child.Birth_Date.Year;
									// Go back to the year the person was born in case of a leap year
									if (child.Birth_Date > today.AddYears(-age)) age--;
									if (age == 0)
									{
										int months = (int)(today.Month - child.Birth_Date.Month);
										if ((int)months < 0)    // correction incase child was born last year
										{
											months += 12;
										}
										if (months < 3)
										{
											throw new Exception(" Can't add baby under 3 months!");
										}
									}
									#endregion

									c.Number = last_contract_number++;
									d.add_contract(c);

									return;
								}
							}
						}
					}
				}
			}
		}

		public void delete_contract(int num)
		{
			d.delete_contract(num);
		}
		public void update_contract(int number, int attribute, string content)
		{
			d.update_contract(number,attribute,content);
		}
		#endregion

		#region list fuctions
		public List<Nanny> get_nanny_list()
		{
			return d.get_nanny_list();
		}
		public List<Mother> get_mother_list()
		{
			return d.get_mother_list();
		}
		public List<Child> get_child_list()
		{
			return d.get_child_list();
		}
		public List<Contract> get_contract_list()
		{
			return d.get_contract_list();
		}
		public List<SortMotherBy> get_sort_mothers_by_list()
		{
			List<SortMotherBy> list = new List<SortMotherBy>();
			list.Add(SortMotherBy.random);
			list.Add(SortMotherBy.Id);
			list.Add(SortMotherBy.LastName);
			list.Add(SortMotherBy.MaxTravelDistance);
			return list;
		}
		public List<Mother> get_mother_list(SortMotherBy sortBy)
		{
			List<Mother> mother_list= d.get_mother_list(); 
			if (sortBy == SortMotherBy.Id)
			{
				mother_list.Sort((mother1, mother2) => (mother1.Id.CompareTo(mother2.Id)));
			}
			if (sortBy == SortMotherBy.MaxTravelDistance)
			{
				mother_list.Sort((mother1, mother2) => (mother1.Max_Travel_Distance.CompareTo(mother2.Max_Travel_Distance)));
			}
			if (sortBy == SortMotherBy.LastName)
			{
				mother_list.Sort((mother1, mother2) => (mother1.Family_Name.CompareTo(mother2.Family_Name)));
			}
			return mother_list;
		}
		#endregion

		#region helper fuctions
		public Double get_distance(string address1, string address2)
		{
			var drivingDirectionRequest = new DirectionsRequest { TravelMode = TravelMode.Driving, Origin = address1, Destination = address2, };

			DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest); Route route = drivingDirections.Routes.First(); Leg leg = route.Legs.First();

			return (int)(leg.Distance.Value)/1000;
		}

		public List<Nanny> check_initial_match(Mother mother)
		{
 
			List<Nanny> matching_nannys = new List<Nanny>();

			foreach (Nanny nanny in get_all_available_nannys())
			{
				bool match = true;
				for (int i = 0; i < 6 && match; i++)
				{
					if (mother.Needs_On_Day[i] && !(nanny.Works_On_Day[i]))
					{
						match = false;
					}
					if (mother.Needs_On_Day[i] && nanny.Works_On_Day[i])
					{
						if (mother.Needs_Hours[0, i] < nanny.Work_Hours[0, i] || mother.Needs_Hours[1, i] > nanny.Work_Hours[1, i])
						{
							match = false;
						}
					}
				}
                
				if (match)
				{
					matching_nannys.Add(nanny);
				}
			}
			return matching_nannys;
		}

		public List<Nanny> check_secondry_match(Mother mother)
		{
			List<Nanny> matching_nannys = check_initial_match(mother);
			List<Nanny> all_nannys = get_all_available_nannys();

			if (matching_nannys.Count > 0)
			{
				return matching_nannys;
			}
			else
			{
				//add nannys working on the same days even of hours are different
				foreach (Nanny nanny in all_nannys)
				{
					bool match = true;
					for (int i = 0; i < 6 && match; i++)
					{
						if (mother.Needs_On_Day[i] && !(nanny.Works_On_Day[i]))
						{
							match = false;
						}
					}
					if (match)
					{
						matching_nannys.Add(nanny);
					}
					if (matching_nannys.Count >= 5)
					{
						return matching_nannys;
					}
				}

				//add addditional nannys
				foreach (Nanny nanny in all_nannys)
				{
					bool already_added = false;
					foreach (var n in matching_nannys)
					{
						if (n.Id == nanny.Id)
						{
							already_added = true;
						}
					}
					if (!already_added)
					{
						matching_nannys.Add(nanny);
					}
					if (matching_nannys.Count >= 5)
					{
						return matching_nannys;
					}
				}
			}
			return matching_nannys;
		}

		public List<Nanny> find_local_nannies(double max_distance, string address)
		{
			List<Nanny> local_nannys = new List<Nanny>();
			foreach (Nanny nanny in get_nanny_list())
			{
				var distance = get_distance(address, nanny.Address);
				if (distance <= max_distance)
				{
					local_nannys.Add(nanny);
				}
			}
			return local_nannys;
		}

		public List<Nanny> get_all_tamat_vacation_nannies()
		{
			List<Nanny> tamat_nannys = new List<Nanny>();
			foreach (Nanny nanny in get_nanny_list())
			{
				if (nanny.Vacation_Like_Tamat)
				{
					tamat_nannys.Add(nanny);
				}
			}
			return tamat_nannys;
		}

		public IEnumerable<Contract> get_contracts_by_condition(Func<Contract, bool> predicate = null)
		{
			return d.get_contract_list().Where(x => predicate(x));
		}
		public int get_amount_of_contracts_by_condition(Func<Contract, bool> predicate = null)
		{
			return d.get_contract_list().Where(x => predicate(x)).Count();
		}
		public IEnumerable<IGrouping<int, Nanny>> get_nannies_by_child_age(bool max, bool sorted = false)
		{
			var nannys_by_age = get_nanny_list().GroupBy(n => ((max)? n.Max_Child_Age : n.Min_Child_Age));
			if (sorted)
			{
				nannys_by_age.OrderByDescending(s => s.Key);
			}
			return nannys_by_age;
		}

		public IEnumerable<IGrouping<int, Contract>> get_contracts_by_distance(string address, bool sorted = false)
		{ 
			var contracts_by_distance = from c in get_contract_list()
										group c by ((int)(get_distance(address, get_nanny_list()[get_nanny_list().FindIndex(n => n.Id == c.Nanny_Id)].Address)) / group_spliter) * group_spliter + group_spliter;	
			if (sorted)
			{
				contracts_by_distance.OrderByDescending(s => s.Key);
			}
			return contracts_by_distance;
		}
		#endregion

		#region custom fuctions
		public List<Child> get_all_nannyless_kids()
		{
			List<Child> nannyless_kids = new List<Child>();
			foreach (Child child in get_child_list())
			{
				bool nannyless = true;
				foreach (Contract cont in get_contract_list())
				{
					if (cont.Child_Id == child.Id)
					{
						nannyless = false;
					}
				}
				if (nannyless)
				{
					nannyless_kids.Add(child);
				}
			}
			return nannyless_kids;
		}

		public List<Nanny> get_all_available_nannys()
		{
			List<Nanny> available_nannys = new List<Nanny>();
			foreach (Nanny nanny in get_nanny_list())
			{
				int children_by_nanny = 0;
				foreach (Contract cont in get_contract_list())
				{
					if (cont.Nanny_Id == nanny.Id)
					{
						children_by_nanny++;
					}
				}
				if (children_by_nanny < nanny.Max_Children)
				{
					available_nannys.Add(nanny);
				}
			}
			return available_nannys;
		}

		public Mother get_mother(Child child)
		{
			foreach (var m in get_mother_list())
			{
				if (m.Id == child.Mother_Id)
				{
					return m;
				}
			}
			return null;
		}

		public string get_positives(Nanny n, Child c, Mother m)
		{
			string positives = "";
			int distance = (int)get_distance(n.Address, m.Home_Address);
			if (n.Elevator_Exists)
			{
				positives += "Elevator Exists, ";
			}

			if(n.Experience_Years >=10)
			{ 
				positives += n.Experience_Years + " Experience Years, ";
			}

			if (n.Recommendations.Length > 0)
			{
				positives += "Recomendations available, ";
			}

			if (n.Rating > 3)
			{
				positives += n.Experience_Years + " stars rating, ";
			}

			if (distance <= 10)
			{
				positives += "Distance is only " + distance + " KM, ";
			}

			positives += "speaks " + n.Lang ;


			return positives;
		}

		public string get_negatives(Nanny n, Child c, Mother m)
		{
			string negatives = "";
			int distance = (int)get_distance(n.Address, m.Home_Address);

			if (!n.Elevator_Exists )
			{
				negatives += "No Elevator and lives on floor " + n.floor + ", ";
			}

			if (n.Experience_Years <= 5)
			{
				negatives += "Only " + n.Experience_Years + " Experience Years, ";
			}

			if(!n.Vacation_Like_Tamat)
			{
				negatives += "Vacations not like tamat, ";
			}

			if (n.Rating < 3)
			{
				negatives += "Only " + n.Experience_Years + " stars rating, ";
			}

			if (distance > 10)
			{
				negatives += "Far! distance is " + distance + " KM, ";
			}

			return negatives;
		}

		public string get_timing_issues(Nanny nanny, Child child, Mother mother)
		{
			string timing_issues = "";
			string[] day = new string[7]{ "Sun", "Mon", "Tue", "Wed", "Thur", "Fri", "Sat"};
			bool first = true;
			for (int i = 0; i < 6; i++)
			{
				if (mother.Needs_On_Day[i] && !(nanny.Works_On_Day[i]))
				{
					if (first)
					{
						timing_issues += "doesn't work on : ";
						first = false;
					}
					timing_issues += day[i] + " ";
				}
			}
			if (!first)
			{
				timing_issues += "\n \t               ";
				first = true;
			}
			for (int i = 0; i < 6; i++)
			{
				if (mother.Needs_On_Day[i] && nanny.Works_On_Day[i])
				{
					if (mother.Needs_Hours[0, i] < nanny.Work_Hours[0, i])
					{
						if (first)
						{
							timing_issues += "starts later than needed on : ";
							first = false;
						}
						timing_issues += day[i] + " ";
					}
				}
			}
			if (!first)
			{
				timing_issues += "\n \t               ";
				first = true;
			}
			for (int i = 0; i < 6; i++)
			{
				if (mother.Needs_On_Day[i] && nanny.Works_On_Day[i])
				{
					if (mother.Needs_Hours[1, i] > nanny.Work_Hours[1, i])
					{
						if (first)
						{
							timing_issues += "finishes earlier than needed on : ";
							first = false;
						}
						timing_issues += day[i] + " ";
					}
				}
			}
			if (timing_issues == "")
			{
				timing_issues += "no issues.";
			}
			return timing_issues;
		}
		#endregion
	}
}
