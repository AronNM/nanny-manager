using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BL
{
    class BL_imp : IBL
    {
		Dal_imp d = new Dal_imp();
		
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
		public void update_nanny(Nanny n)
		{
			d.update_nanny(n);
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
		public void update_mother(Mother m)
		{
			d.update_mother(m);
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
		public void update_child(Child c)
		{
			d.update_child(c);
		}
		#endregion

		#region contract fuctions
		public void add_contract(Contract c)
		{
			foreach (var child in d.get_child_list())	// find instance of the relevent child
			{
				if (c.Child_Id == child.Id)
				{
					foreach (var nanny in d.get_nanny_list())	// find instance of the relevent nanny
					{
						if (c.Nanny_Id == nanny.Id)
						{
							foreach (var mother in d.get_mother_list())	// find instance of the relevent mother
							{
								if (child.Mother_Id == mother.Id)
								{
									#region insert monthly price
									// calulate mounthly payment 
									if (!(c.Price_Is_Hourly))
									{
										c.Monthly_Price = c.;
									}
									if (c.Price_Is_Hourly)
									{
										c.Monthly_Price = c.;
									}
									#endregion

									#region give sibling discount

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
		public void update_contract(Contract c)
		{
			d.update_contract(c);
		}
		#endregion

		#region contract fuctions
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
		#endregion

		#region helper fuctions
		public Double get_distance(string address1, string address2);
		public List<Nanny> check_initial_match(Mother m);
		public List<Nanny> check_secondry_match(Mother m);
		public List<Nanny> find_local_nannies(double max_distance, string address);
		public List<Child> get_all_nannyless_kids();
		public List<Nanny> get_all_tamat_vacation_nannies();
		public IEnumerable<Contract> get_contracts_by_condition(Func<Contract, bool> predicate = null);
		public int get_amount_of_contracts_by_condition(Func<Contract, bool> predicate = null);
		public IEnumerable<public List<Nanny>> get_nannies_by_child_age(bool max, bool sorted = false);
		public IEnumerable<public List<Contract>> get_contracts_by_distance(string address, bool sorted = false);
		#endregion

		#region custom fuctions
		//add fuctions
		#endregion
	}
}
