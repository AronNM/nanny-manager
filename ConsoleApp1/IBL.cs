using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
	/// <summary>
	/// This interface contains function defenitions for all the functions which contain the system logic and act as interactors between the UI and the DAL layer
	/// </summary>
	public interface IBL
	{
		#region nanny fuctions
		/// <summary>
		/// function to add new nanny
		/// </summary>
		/// <param name="n"></param>
		void add_nanny(Nanny n);

		/// <summary>
		/// function to delete existing nanny
		/// </summary>
		/// <param name="n"></param>
		void delete_nanny(Nanny n);

		/// <summary>
		/// function to update existing nanny
		/// </summary>
		/// <param name="temp"></param>
		/// <param name="id"></param>
		//void update_nanny(int i, int s, string s2);
       // void update_nanny(int i, int s, bool[] b, TimeSpan[,] t);
        void update_nanny(Nanny temp,int id);
        #endregion

        #region mother fuctions
		/// <summary>
		/// Add new Mother
		/// </summary>
		/// <param name="m"></param>
        void add_mother(Mother m);

		/// <summary>
		/// delete existing mother
		/// </summary>
		/// <param name="m"></param>
		void delete_mother(Mother m);

		/// <summary>
		/// update existing mother - update a string attribute
		/// </summary>
		/// <param name="id"></param>
		/// <param name="atributte"></param>
		/// <param name="s"></param>
		void update_mother(int id, int atributte, string s);

		/// <summary>
		/// update existing mother - update a timespan attribute
		/// </summary>
		/// <param name="id"></param>
		/// <param name="atributte"></param>
		/// <param name="b"></param>
		/// <param name="t"></param>
		void update_mother(int id, int atributte, bool[] b,TimeSpan[,] t);

		/// <summary>
		/// update existing mother - update the ID
		/// </summary>
		/// <param name="temp"></param>
		/// <param name="id"></param>
		void update_mother(Mother temp,int id);
        #endregion

        #region child fuctions
		/// <summary>
		/// Add new child
		/// </summary>
		/// <param name="c"></param>
        void add_child(Child c);

		/// <summary>
		/// delete existing child
		/// </summary>
		/// <param name="c"></param>
		void delete_child(Child c);

		/// <summary>
		/// update existing child - update a string attribute
		/// </summary>
		/// <param name="id"></param>
		/// <param name="atributte"></param>
		/// <param name="s"></param>
		void update_child(int id, int atributte, string s);

		/// <summary>
		/// update existing mother - update the ID
		/// </summary>
		/// <param name="temp"></param>
		/// <param name="id"></param>
		void update_child(Child temp,int id);

		/// <summary>
		/// update existing mother - update 2 string attribute
		/// </summary>
		/// <param name="id"></param>
		/// <param name="atributte"></param>
		/// <param name="s"></param>
		/// <param name="s2"></param>
		void update_child(int id, int atributte, string s, string s2);

        #endregion

        #region contract fuctions
		/// <summary>
		/// add new contract safely
		/// </summary>
		/// <param name="c"></param>
        void add_contract(Contract c);

		/// <summary>
		/// Add contract not safely
		/// </summary>
		/// <param name="c"></param>
        void add_contract_manually(Contract c);

		/// <summary>
		/// delete existing contract
		/// </summary>
		/// <param name="c"></param>
        void delete_contract(Contract c);

		/// <summary>
		/// update existing contract - update a string attribute
		/// </summary>
		/// <param name="number"></param>
		/// <param name="attribute"></param>
		/// <param name="content"></param>
		void update_contract(int number, int attribute, string content);

		/// <summary>
		/// update existing contract - update ID
		/// </summary>
		/// <param name="c"></param>
		/// <param name="id"></param>
		void update_contract(Contract c,int id);
        #endregion

        #region get list fuctions

		/// <summary>
		/// get list of all existing nannies
		/// </summary>
		/// <returns></returns>
        List<Nanny> get_nanny_list();

		/// <summary>
		/// get list of all existing mothers
		/// </summary>
		/// <returns></returns>
		List<Mother> get_mother_list();

		/// <summary>
		/// get list of all existing mothers sorted by enum SORTMOTHERBY
		/// </summary>
		/// <param name="sortBy"></param>
		/// <returns></returns>
		List<Mother> get_mother_list(SortMotherBy sortBy);

		/// <summary>
		/// get list of all existing children
		/// </summary>
		/// <returns></returns>
		List<Child> get_child_list();

		/// <summary>
		/// get list of all existing contracts
		/// </summary>
		/// <returns></returns>
		List<Contract> get_contract_list();

		/// <summary>
		/// get list of all mothers sorted  conditions
		/// </summary>
		/// <returns></returns>
		List<SortMotherBy> get_sort_mothers_by_list();

		/// <summary>
		/// get list of all existing nannies conditions
		/// </summary>
		/// <returns></returns>
		List<SortNannyBy> get_sort_nannies_by_list();

		/// <summary>
		/// get list of all existing nanny by condition
		/// </summary>
		/// <param name="sortBy"></param>
		/// <returns></returns>
		List<Nanny> get_nanny_list(SortNannyBy sortBy);
		List<ContractCondition> get_contract_condition_list();
		#endregion

		#region helper fuctions
		/// <summary>
		/// get distance using google API
		/// </summary>
		/// <param name="address1"></param>
		/// <param name="address2"></param>
		/// <returns></returns>
		Double get_distance(string address1, string address2);

		/// <summary>
		/// find matching nannies
		/// </summary>
		/// <param name="m"></param>
		/// <returns></returns>
		List<Nanny> check_initial_match(Mother m);

		/// <summary>
		/// find non matching but close nannies
		/// </summary>
		/// <param name="m"></param>
		/// <returns></returns>
		List<Nanny> check_secondry_match(Mother m);

		/// <summary>
		/// /find local nannies
		/// </summary>
		/// <param name="max_distance"></param>
		/// <param name="address"></param>
		/// <returns></returns>
		List<Nanny> find_local_nannies(double max_distance, string address);

		/// <summary>
		/// get children who dont have a nanny
		/// </summary>
		/// <returns></returns>
		List<Child> get_all_nannyless_kids();

		/// <summary>
		/// get children with special needs
		/// </summary>
		/// <returns></returns>
		List<Child> get_all_specialNeeds_kids();

		/// <summary>
		/// get children with tamat vacatins
		/// </summary>
		/// <returns></returns>
		List<Nanny> get_all_tamat_vacation_nannies();

		/// <summary>
		/// get contract by condition (LAMBDA expression can be used here - using DELEGATE FUNC)
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		IEnumerable<Contract> get_contracts_by_condition(Func<Contract, bool> predicate = null);

		/// <summary>
		/// using predicate getnumber of contracts by condition
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		int get_amount_of_contracts_by_condition(Func<Contract, bool> predicate = null);

		/// <summary>
		/// using IGROUPING returns nannies by age group
		/// </summary>
		/// <param name="max"></param>
		/// <param name="sorted"></param>
		/// <returns></returns>
		IEnumerable<IGrouping<int, Nanny>> get_nannies_by_child_age(bool max, bool sorted = false);

		/// <summary>
		/// using IGROUPING return contracts by distance
		/// </summary>
		/// <param name="address"></param>
		/// <param name="sorted"></param>
		/// <returns></returns>
		IEnumerable<IGrouping<int, Contract>> get_contracts_by_distance(string address, bool sorted = false);
		#endregion

		#region custom fuctions
		/// <summary>
		/// get all nannies that arem't full
		/// </summary>
		/// <returns></returns>
		List<Nanny> get_all_available_nannys();

		/// <summary>
		/// find mother of specific child
		/// </summary>
		/// <param name="child"></param>
		/// <returns></returns>
		Mother get_mother(Child child);

		/// <summary>
		/// get positives for a specific match
		/// </summary>
		/// <param name="n"></param>
		/// <param name="c"></param>
		/// <param name="m"></param>
		/// <returns></returns>
		string get_positives(Nanny n, Child c, Mother m);

		/// <summary>
		/// get negatives for a specific match
		/// </summary>
		/// <param name="n"></param>
		/// <param name="c"></param>
		/// <param name="m"></param>
		/// <returns></returns>
		string get_negatives(Nanny n, Child c, Mother m);

		/// <summary>
		/// get timingissues for a specific match
		/// </summary>
		/// <param name="n"></param>
		/// <param name="c"></param>
		/// <param name="m"></param>
		/// <returns></returns>
		string get_timing_issues(Nanny n, Child c, Mother m);
		#endregion
	}
}
