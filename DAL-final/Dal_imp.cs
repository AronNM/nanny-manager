using System;
//this class implements the dal functions which access the data (DS)
using System.Collections.Generic;
using System.Text;
using DS_final;
using BE;

namespace DAL_final
{
    public class Dal_imp : Idal
    {
        #region nanny fuctions
        public void add_nanny(Nanny n)
        {
            foreach (var item in DataSource.Nannys_List)
            {
                if (n.Id == item.Id)
                {
                    throw new Exception("ID already exists!");
                }
               
            }
            DataSource.Nannys_List.Add(n);
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

        public void update_nanny(int id, int attribute, string s)
        {
            foreach (var item in DataSource.Nannys_List)
            {
                if (id == item.Id)
                {
                    Nanny temp = new Nanny();
                    temp = item;
                    switch(attribute)
                    {
                        case 1:
                            temp.Id = int.Parse(s);
                            break;
                        case 2:
                            temp.First_Name = s;
                            break;
                        case 3:
                            temp.Family_Name = s;
                            break;
                        case 4:
                            temp.Birth_Date = Convert.ToDateTime(s);
                            break;
                        case 5:
                            temp.Telephone_Number = s;
                            break;
                        case 6:
                            temp.floor = int.Parse(s);
                            break;
                        case 7:
                            temp.Experience_Years = int.Parse(s);
                            break;
                        case 8:
                            temp.Max_Children = int.Parse(s);
                            break;
                        case 9:
                            temp.Max_Child_Age= int.Parse(s);
                            break;
                        case 10:
                            temp.Min_Child_Age = int.Parse(s);
                            break;
                        case 11:
                            if (s == "true")
                                temp.Hourly_Price_Exists = true;
                            if (s == "false")
                                temp.Hourly_Price_Exists = false;
                            break;
                        case 13:
                            if (s == "true")
                                temp.Elevator_Exists = true;
                            if (s == "false")
                                temp.Elevator_Exists = false;

                            break;

                    }
                    DataSource.Nannys_List.Remove(item);
                    DataSource.Nannys_List.Add(temp);
                    return;
                }
                //if reached here - 
                
            }
            throw new Exception("ID doesn't exists!");
        }
        public void update_nanny(int id, int attribute, bool[] b, TimeSpan[,] t)
        {
            foreach (var item in DataSource.Nannys_List)
            {
                if (id == item.Id)
                {
                    Nanny temp = new Nanny();
                    temp = item;
                    temp.Works_On_Day = b;
                    temp.Work_Hours = t;
                    DataSource.Nannys_List.Remove(item);
                    DataSource.Nannys_List.Add(temp);
                    return;
                }
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
                
            }
            DataSource.Mothers_List.Add(m);
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

        public void update_mother(int id, int attribute, string s)
        {
            foreach (var item in DataSource.Mothers_List)
            {
                if (id == item.Id)
                {
                    Mother temp = new Mother();
                    temp = item;
                    switch (attribute)
                    {
                        case 1:
                            temp.Id = int.Parse(s);
                            break;
                        case 2:
                            temp.First_Name = s;
                            break;
                        case 3:
                            temp.Family_Name = s;
                            break;
                        case 4:
                            temp.Telephone_Number = s;
                            break;
                        case 5:
                            temp.Home_Address = s;
                            break;
                        case 6:
                            temp.Second_Address = s;
                            break;
                        case 7:
                            temp.Max_Travel_Distance = int.Parse(s);
                            break;
                        case 9:
                            temp.Comments = s;
                            break;




                    }

                    DataSource.Mothers_List.Remove(item);
                    DataSource.Mothers_List.Add(temp);
                    return;
                }
                //if reached here - 
            }
            throw new Exception("ID doesn't exists!");
        }
        public void update_mother(int id, int attribute, bool[] b, TimeSpan[,] t)
        {
            foreach (var item in DataSource.Mothers_List)
            {
                if (id == item.Id)
                {
                    Mother temp = new Mother();
                    temp = item;
                    temp.Needs_On_Day = b;
                    temp.Needs_Hours = t;
                    DataSource.Mothers_List.Remove(item);
                    DataSource.Mothers_List.Add(temp);
                    return;
                }
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
                
            }
            DataSource.Children_List.Add(c);
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

        public void update_child(int id, int attribute, string s)
        {
            foreach (var item in DataSource.Children_List)
            {
                if (id == item.Id)
                {
                    Child temp = new Child();
                    temp = item;
                    switch(attribute)
                    {
                        case 1:
                            temp.Id = int.Parse(s);
                            break;
                        case 2:
                            temp.Mother_Id= int.Parse(s);
                            break;
                        case 3:
                            temp.First_Name = s;
                            break;

                    }
                    DataSource.Children_List.Remove(item);
                    DataSource.Children_List.Add(temp);
                    return;
                }
                //if reached here - 
                
            }
            throw new Exception("ID doesn't exists!");
        }
        public void update_child(int id, int attribute, string s,string s2)
        {
            foreach (var item in DataSource.Children_List)
            {
                if (id == item.Id)
                {
                    Child temp = new Child();
                    temp = item;
                    if (s == "true")
                    {
                        temp.Special_Needs = true;
                        temp.Needs = s2;
                    }
                    if (s == "false")
                    {
                        temp.Special_Needs = false;
                        temp.Needs = "";
                    }
                    return;
                    
                }
            }
            throw new Exception("ID doesn't exists!");
        }
        #endregion

        #region contract fuctions
        public void add_contract(Contract c)
        {
            
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

        public void update_contract(int number, int attribute, string content)
        {
            foreach(Contract item in DataSource.Contracts_List)
            {
                if(number==item.Number)
                {
                    switch (attribute)
                    {
                        case 1:
                            if (content == "true")
                                item.Signed = true;
                            if (content == "false")
                                item.Signed = false;
                            break;
                        case 2:
                            item.Monthly_Price = double.Parse(content);
                            break;
                        case 3:
                            item.Starts=  Convert.ToDateTime(content);
                            break;
                        case 4:
                            item.Ends= Convert.ToDateTime(content);
                            break;
                    }
                }
            }
            
            //if reached here - 
            //throw new Exception("a contract with this number doesn't exists!");
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
