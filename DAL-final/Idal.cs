using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL_final
{
    public interface Idal
    {
        #region nanny fuctions
        void add_nanny(Nanny n);
        void delete_nanny(int id);
        void update_nanny(int id, int attribute, string s);
       // void update_nanny(int id, int attribute, bool[] s);
        void update_nanny(int id, int attribute, bool[] s,TimeSpan[,] t);
        #endregion

        #region mother fuctions
        void add_mother(Mother m);
        void delete_mother(int id);
        void update_mother(int id, int attribute, string s);
        void update_mother(int id, int attribute, bool[] b, TimeSpan[,] t);
        #endregion

        #region child fuctions
        void add_child(Child c);
        void delete_child(int id);
        void update_child(int id, int attribute, string s);
        void update_child(int id, int attribute, string s,string s2);
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
    }
}
