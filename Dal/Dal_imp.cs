using System;
using System.Collections.Generic;
using System.Text;
using DS;
using BE;

namespace DAL
{
	public class Dal_imp : Idal
	{
		static int last_contract_number = 11111111;

		#region nanny fuctions
		public void add_nanny(Nanny n)
		{
			foreach (var item in DataSource.Nannys_List)
			{
				if (n.Id == item.Id)
				{
					throw new Exception("ID already exists!");
				}
				DataSource.Nannys_List.Add(n);
			}
		}


		public void delete_nanny(int id)
		{
			foreach (var item in DataSource.Nannys_List)
			{
				if (id == item.Id)
				{
					DataSource.Nannys_List.Remove(item);
					return;
				}
			}
			//if reached here - 
			throw new Exception("ID doesn't exists!");
		}

		public void update_nanny(Nanny n)
		{
			foreach (var item in DataSource.Nannys_List)
			{
				if (n.Id == item.Id)
				{
					DataSource.Nannys_List.Remove(item);
					DataSource.Nannys_List.Add(n);
					return;
				}
				//if reached here - 
				throw new Exception("ID doesn't exists!");
			}
		}
		#endregion

		#region mother fuctions
		public void add_mother(Mother m)
		{
			foreach (var item in DataSource.Mothers_List)
			{
				if (m.Id == item.Id)
				{
					throw new Exception("ID already exists!");
				}
				DataSource.Mothers_List.Add(m);
			}
		}


		public void delete_mother(int id)
		{
			foreach (var item in DataSource.Mothers_List)
			{
				if (id == item.Id)
				{
					DataSource.Mothers_List.Remove(item);
					return;
				}
			}
			//if reached here - 
			throw new Exception("ID doesn't exists!");
		}

		public void update_mother(Mother m)
		{
			foreach (var item in DataSource.Mothers_List)
			{
				if (m.Id == item.Id)
				{
					DataSource.Mothers_List.Remove(item);
					DataSource.Mothers_List.Add(m);
					return;
				}
				//if reached here - 
				throw new Exception("ID doesn't exists!");
			}
		}
		#endregion

		#region child fuctions
		public void add_child(Child c)
		{
			foreach (var item in DataSource.Children_List)
			{
				if (c.Id == item.Id)
				{
					throw new Exception("ID already exists!");
				}
				DataSource.Children_List.Add(c);
			}
		}


		public void delete_child(int id)
		{
			foreach (var item in DataSource.Children_List)
			{
				if (id == item.Id)
				{
					DataSource.Children_List.Remove(item);
					return;
				}
			}
			//if reached here - 
			throw new Exception("ID doesn't exists!");
		}

		public void update_child(Child c)
		{
			foreach (var item in DataSource.Children_List)
			{
				if (c.Id == item.Id)
				{
					DataSource.Children_List.Remove(item);
					DataSource.Children_List.Add(c);
					return;
				}
				//if reached here - 
				throw new Exception("ID doesn't exists!");
			}
		}
		#endregion

		#region contract fuctions
		public void add_contract(Contract c)
		{
			last_contract_number++;
			//validation happens in BL namespace
			DataSource.Contracts_List.Add(c);
		}
		public void delete_contract(int num)
		{
			foreach (var item in DataSource.Contracts_List)
			{
				if (num == item.Number)
				{
					DataSource.Contracts_List.Remove(item);
					return;
				}
			}
			//if reached here - 
			throw new Exception("contract num:" + num + " doesn't exists!");
		}

		public void update_contract(Contract c)
		{
			foreach (var item in DataSource.Contracts_List)
			{
				if (c.Number == item.Number)
				{
					DataSource.Contracts_List.Remove(item);
					DataSource.Contracts_List.Add(c);
					return;
				}
			}
			//if reached here - 
			throw new Exception("a contract with this number doesn't exists!");
		}
		#endregion

		#region get lists fuctions
		public List<Nanny> get_nanny_list()
		{
			return DataSource.Nannys_List;
		}

		public List<Mother> get_mother_list()
		{
			return DataSource.Mothers_List;
		}

		public List<Child> get_child_list()
		{
			return DataSource.Children_List;
		}

		public List<Contract> get_contract_list()
		{
			return DataSource.Contracts_List;
		}
		#endregion

	}
}
