using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface Idal 
    {
		#region nanny fuctions
		void add_nanny(Nanny n);
		void delete_nanny(int id);
		void update_nanny(Nanny n);
		#endregion

		#region mother fuctions
		void add_mother(Mother m);
		void delete_mother(int id);
		void update_mother(Mother m);
		#endregion

		#region child fuctions
		void add_child(Child c);
		void delete_child(int id);
		void update_child(Child c);
		#endregion

		#region contract fuctions
		void add_contract(Contract c);
		void delete_contract(int num);
		void update_contract(Contract c);
		#endregion

		#region contract fuctions
		List<Nanny> get_nanny_list();
		List<Mother> get_mother_list();
		List<Child> get_child_list();
		List<Contract> get_contract_list();
		#endregion
	}
}
