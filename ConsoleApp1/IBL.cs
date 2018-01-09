using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
	public interface IBL
	{
		#region nanny fuctions
		void add_nanny(Nanny n);
		void delete_nanny(int id);
		void update_nanny(int i, int s, string s2);
        void update_nanny(int i, int s, bool[] b, TimeSpan[,] t);
        #endregion

        #region mother fuctions
        void add_mother(Mother m);
		void delete_mother(int id);
		void update_mother(int id, int atributte, string s);
        void update_mother(int id, int atributte, bool[] b,TimeSpan[,] t);
        #endregion

        #region child fuctions
        void add_child(Child c);
		void delete_child(int id);
		void update_child(int id, int atributte, string s);
        void update_child(int id, int atributte, string s, string s2);

        #endregion

        #region contract fuctions
        void add_contract(Contract c);
		void delete_contract(int num);
		void update_contract(int number, int attribute, string content);
		#endregion

		#region get list fuctions
		List<Nanny> get_nanny_list();
		List<Mother> get_mother_list();
		List<Child> get_child_list();
		List<Contract> get_contract_list();
		#endregion

		#region helper fuctions
		Double get_distance(string address1, string address2);
		List<Nanny> check_initial_match(Mother m);
		List<Nanny> check_secondry_match(Mother m);
		List<Nanny> find_local_nannies(double max_distance, string address);
		List<Child> get_all_nannyless_kids();
		List<Nanny> get_all_tamat_vacation_nannies();
		IEnumerable<Contract> get_contracts_by_condition(Func<Contract, bool> predicate = null);
		int get_amount_of_contracts_by_condition(Func<Contract, bool> predicate = null);
		IEnumerable<IGrouping<int, Nanny>> get_nannies_by_child_age(bool max, bool sorted = false);
		IEnumerable<IGrouping<int, Contract>> get_contracts_by_distance(string address, bool sorted = false);
		#endregion

		#region custom fuctions
		List<Nanny> get_all_available_nannys();
		Mother get_mother(Child child);
		string get_positives(Nanny n, Child c, Mother m);
		string get_negatives(Nanny n, Child c, Mother m);
		string get_timing_issues(Nanny n, Child c, Mother m);
		#endregion
	}
}
