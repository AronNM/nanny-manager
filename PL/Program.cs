
//this file contains the PL class which is the UI using the consol
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;

namespace PL
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            BL_imp bl = new BL_imp();
            initialize(bl);
			Console.WriteLine("\n\n\n");
			Console.WriteLine("***************************************************************************");
			Console.WriteLine("****************** WELCOME TO NANNY - CHILD MATCHER APP *******************");
			Console.WriteLine("***************************************************************************");
			Console.WriteLine("\n\n\n");

			int menuchoice = 1;
            while (menuchoice != 0)
            {
				try
				{
					Console.WriteLine("\n" + "MENU");
					Console.WriteLine("1. Add a nanny");
					Console.WriteLine("2. Delete a nanny");
					Console.WriteLine("3. Update a nanny");
					Console.WriteLine("4. Add a mother");
					Console.WriteLine("5. Delete a mother");
					Console.WriteLine("6. Update a mother");
					Console.WriteLine("7. Add a child");
					Console.WriteLine("8. Delete a child");
					Console.WriteLine("9. Update a child");
					Console.WriteLine("10. Add a contract");
					Console.WriteLine("11. Delete a contract");
					Console.WriteLine("12. Update a contract");
					Console.WriteLine("13. Get a list of all nannys");
					Console.WriteLine("14. Get a list of all mothers");
					Console.WriteLine("15. Get a list of all children");
					Console.WriteLine("16. Get a list of all contracts");
					Console.WriteLine("0. Exit");
					Console.WriteLine("");

					menuchoice = int.Parse(Console.ReadLine());
					Console.Clear();

					switch (menuchoice)
					{
						case 0:
							break;
						case 1:
							Console.WriteLine("1. Add a nanny");
							Console.WriteLine("");
							Console.WriteLine("Enter the new nanny data");
							Nanny temp = new Nanny();
							Console.WriteLine("Id: ");
							temp.Id = int.Parse(Console.ReadLine());
							Console.WriteLine("First Name: ");
							temp.First_Name = Console.ReadLine();
							Console.WriteLine("Family Name: ");
							temp.Family_Name = Console.ReadLine();
							Console.WriteLine("Address: ");
							temp.Address = Console.ReadLine();
							Console.WriteLine("Birth date: ");
							temp.Birth_Date = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Telephone Number: ");
                            temp.Telephone_Number = Console.ReadLine();
                            Console.WriteLine("Is Elevator? Enter true or false ");
							temp.Elevator_Exists = (Console.ReadLine().ToLower() == "true");
							Console.WriteLine("Experience years: ");
							temp.Experience_Years = int.Parse(Console.ReadLine());
							Console.WriteLine("Floor: ");
							temp.floor = int.Parse(Console.ReadLine());
							Console.WriteLine("Hourly price exists? Enter true or false ");
							temp.Hourly_Price_Exists = (Console.ReadLine() == "true");
							if (temp.Hourly_Price_Exists)
							{
								Console.WriteLine("Enter the hourly price");
								temp.Hourly_Price = double.Parse(Console.ReadLine());
							}
							else
							{
								Console.WriteLine("Enter the monthly price");
								temp.Monthly_Price = double.Parse(Console.ReadLine());
							}
							Console.WriteLine("Language: ");
							string language = Console.ReadLine();
							Language l = (Language)Enum.Parse(typeof(Language), language.ToUpper());
							Console.WriteLine("How many children she can take?: ");
							temp.Max_Children = int.Parse(Console.ReadLine());
							Console.WriteLine("Maximum children age she can take: ");
							temp.Max_Child_Age = int.Parse(Console.ReadLine());
							Console.WriteLine("Minimum children age she can take: ");
							temp.Min_Child_Age = int.Parse(Console.ReadLine());
							Console.WriteLine("Recomendations: ");
							temp.Recommendations = Console.ReadLine();

							for (int i = 0; i < 6; i++)
							{
								Week w = (Week)i + 1;
                                Console.Write("Dos she works in ");
                                Console.Write(w);
                                Console.WriteLine("? Enter true or false");
                                string choice = Console.ReadLine();
                                if (choice.ToLower() == "true")
                                    temp.Works_On_Day[i] =true;
                                if(choice.ToLower() == "false")
                                    temp.Works_On_Day[i] = false;
                                if (temp.Works_On_Day[i])
								{
                                    Console.Write("Enter the hour she begins to work in ");
                                    Console.Write(w);
                                    Console.WriteLine("? Enter hh:mm");
                                    temp.Work_Hours[i, 0] = TimeSpan.Parse(Console.ReadLine());
                                    Console.Write("Enter the hour she finishes to work in ");
                                    Console.Write(w);
                                    Console.WriteLine("? Enter hh:mm");
                                    temp.Work_Hours[i, 1] = TimeSpan.Parse(Console.ReadLine());
                                }
							}
							bl.add_nanny(temp);
							break;
						case 2:
							Console.WriteLine("2. Delete a nanny");
							Console.WriteLine("");
							Console.WriteLine("Enter the id of the nanny you want to delete");
							int id = int.Parse(Console.ReadLine());
							bl.delete_nanny(id);
							break;
						case 3:
							Console.WriteLine("3. Update a nanny");
							Console.WriteLine("");
							UpdatingNanny(bl);
							break;
						case 4:
							Console.WriteLine("4. Add a mother");
							Console.WriteLine("");
							Console.WriteLine("Enter the new mother data");
							Mother addMother = new Mother();
							Console.WriteLine("Id: ");
							addMother.Id = int.Parse(Console.ReadLine());
                            Console.WriteLine("First Name: ");
                            addMother.First_Name = Console.ReadLine();
                            Console.WriteLine("Family Name: ");
                            addMother.Family_Name = Console.ReadLine();
							Console.WriteLine("Home Address: ");
							addMother.Home_Address = Console.ReadLine();
							Console.WriteLine("Second Address: ");
							addMother.Second_Address = Console.ReadLine();
							Console.WriteLine("Max travel distance: ");
							addMother.Max_Travel_Distance = double.Parse(Console.ReadLine());
							Console.WriteLine("Telephone Number: ");
							addMother.Telephone_Number = Console.ReadLine();

							for (int i = 0; i < 6; i++)
							{
								Week w = (Week)i + 1;
								Console.Write("Dos she needs in ");
								Console.Write(w);
								Console.WriteLine("? Enter true or false");
								string s = Console.ReadLine();
								if ((s.ToLower() == "true"))
								{
									addMother.Needs_On_Day[i] = true;
								}
								else
								{
									addMother.Needs_On_Day[i] = false;
								}
								if (addMother.Needs_On_Day[i])
								{
									Console.Write("Enter the hour she brings the child in ");
									Console.Write(w);
									Console.WriteLine("? Enter hh:mm");
									addMother.Needs_Hours[i, 0] = TimeSpan.Parse(Console.ReadLine());
									Console.Write("Enter the hour she takes the child in ");
									Console.Write(w);
									Console.WriteLine("? Enter hh:mm");
									addMother.Needs_Hours[i, 1] = TimeSpan.Parse(Console.ReadLine());
								}
							}

							bl.add_mother(addMother);

							break;
						case 5:

							Console.WriteLine("5. Delete a mother");
							Console.WriteLine("");
							Console.WriteLine("Enter the id of the mother you want to delete");
							int idMother = int.Parse(Console.ReadLine());
							bl.delete_mother(idMother);
							break;
						case 6:
							Console.WriteLine("6. Update a mother");
							Console.WriteLine("");
							UpdatingMother(bl);
							break;
						case 7:
							Console.WriteLine("7. Add a child");
							Console.WriteLine("");
							Console.WriteLine("Enter the new child data");

							Child addChild = new Child();
							Console.WriteLine("Id: ");
							addChild.Id = int.Parse(Console.ReadLine());
							Console.WriteLine("Mother id: ");
							addChild.Mother_Id = int.Parse(Console.ReadLine());
							Console.WriteLine("First Name: ");
							addChild.First_Name = Console.ReadLine();
							Console.WriteLine("Birth date: ");
							addChild.Birth_Date = Convert.ToDateTime(Console.ReadLine());
							Console.WriteLine("Does the child need special needs? Enter true or false ");
							string b = Console.ReadLine().ToLower();
							if (b == "true")
							{
								addChild.Special_Needs = true;
							}
							else addChild.Special_Needs = false;
							if (addChild.Special_Needs)
							{
								Console.WriteLine("What is the child's special needs? ");
								addChild.Needs = Console.ReadLine();
							}


							bl.add_child(addChild);
							break;
						case 8:
							Console.WriteLine("8. Delete a child");
							Console.WriteLine("");
							Console.WriteLine("Enter the id of the child you want to delete");
							int idChild = int.Parse(Console.ReadLine());
							bl.delete_child(idChild);
							break;
						case 9:
							Console.WriteLine("9. Update a child");
							Console.WriteLine("");
							UpdatingChild(bl);
							break;
						case 10:
							Console.WriteLine("10. Add a contract");
							Console.WriteLine("");
							AddContract(bl);
							break;
						case 11:
							Console.WriteLine("11. Delete a contract");
							Console.WriteLine("");
							Console.WriteLine("Enter the id of the contract you want to delete");
							int idContract = int.Parse(Console.ReadLine());
							bl.delete_contract(idContract);
							break;
						case 12:
							Console.WriteLine("12. Update a contract");
							Console.WriteLine("");
							UpdatingContract(bl);
							break;
						case 13:
							Console.WriteLine("13. Get a list of all nannys");
							Console.WriteLine("");
							List<Nanny> all_nannys = new List<Nanny>();
							all_nannys = bl.get_nanny_list();
                            if (all_nannys.Count != 0)
                            {
                                foreach (Nanny n in all_nannys)
                                {
                                    string print = n.ToString();
                                    Console.WriteLine(print);
                                }
                            }
                            else Console.WriteLine("There are no nannys registered.");
                            break;
						case 14:
							Console.WriteLine("14. Get a list of all mothers");
							Console.WriteLine("");
							List<Mother> all_mothers = new List<Mother>();
							all_mothers = bl.get_mother_list();
                            if (all_mothers.Count != 0)
                            {
                                foreach (Mother m in all_mothers)
                                {
                                    Console.WriteLine(m.ToString());
                                }
                            }
                            else Console.WriteLine("There are no mothers registered.");
							break;
						case 15:
							Console.WriteLine("15. Get a list of all children");
							Console.WriteLine("");
							List<Child> all_children = new List<Child>();
							all_children = bl.get_child_list();
                            if (all_children.Count != 0)
                            {
                                foreach (Child c in all_children)
                                {
                                    Console.WriteLine(c.ToString());
                                }
                            }
                            else Console.WriteLine("There are no children registered.");
                            break;
						case 16:
							Console.WriteLine("16. Get a list of all contracts");
							Console.WriteLine("");
							List<Contract> all_contracts = new List<Contract>();
							all_contracts = bl.get_contract_list();
                            if (all_contracts.Count != 0)
                            {
                                foreach (Contract c in all_contracts)
                                {
                                    Console.WriteLine(c.ToString());
                                }
                            }
                            else Console.WriteLine("There are no contracts registered.");
                            break;
						default:
							Console.WriteLine("Sorry, invalid selection!");
							break;
					}
				}
				catch (Exception exception)
				{
					Console.WriteLine("\nError: " + exception.Message + "\nTry again...\n");
				}

			}
        }

        private static void AddContract(BL_imp bl)
        {
			Console.Clear();
			Console.WriteLine("Welcome To Contract Creater Wizard!\n");
			Console.WriteLine("Below is a list of the nannyless children. Please enter the number representing the child you'd like to create a contract for:\n");
			var nannyless_children = bl.get_all_nannyless_kids();
			int counter = 0, selected_child, selected_nanny;
			foreach (Child c in nannyless_children)
			{
				Console.WriteLine("{0}.\t{1}", ++counter, c.ToString());
			}
			Console.Write("\nI choose child num: ");
			selected_child = int.Parse(Console.ReadLine());

			var child = nannyless_children[selected_child-1];
			var mother = bl.get_mother(child);

			var available_nannies = bl.check_secondry_match(mother);	//will return initiall match if exists

			//perfect matches are avalable
			bool perfect_matches = false;
			if (bl.check_initial_match(mother).Count > 0)
			{
				Console.WriteLine("\nBelow is a table with nannys available on the hours " + child.First_Name + " needs.\n" +
						"Please enter the number representing the nanny you'd like to set up with " + child.First_Name + ":\n");
				perfect_matches = true;
			}

			//no perfect matches are avalable
			else
			{
				Console.WriteLine("\nThere are no perfect matches available.\nBelow is a table with nannys available on some of the times " + child.First_Name + " needs.\n" +
						"Please enter the number representing the nanny you'd like to set up with " + child.First_Name + ":\n");
			}

			counter = 0;
			Console.WriteLine(" \t{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}\n", "First Name", "Last Name", "ID", "Distance", "Price");
			foreach (Nanny n in available_nannies)
			{
				Console.WriteLine(++counter + "\t{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}", n.First_Name, n.Family_Name, n.Id,
					bl.get_distance(mother.Home_Address, n.Address) + " KM", ((n.Hourly_Price_Exists) ? (n.Hourly_Price + "(hourly)") : (n.Monthly_Price + "(monthly)")) );
			}

			counter = 0;
			Console.WriteLine("\nHere is a list of Pros & Cons for each nanny to help you decide:\n");
			foreach (Nanny n in available_nannies)
			{
				Console.WriteLine(++counter + "\t{0} {1}:", n.First_Name, n.Family_Name);
				Console.WriteLine(" \tPositives: {0}", bl.get_positives(n, child, mother));
				Console.WriteLine(" \tNegatives: {0}", bl.get_negatives(n, child, mother));
				Console.WriteLine((!(perfect_matches) ? " \tTiming issues: {0}\n" : "\n"), bl.get_timing_issues(n, child, mother));
			}

			Console.Write("\nI choose nanny num: ");
			selected_nanny = int.Parse(Console.ReadLine());
			var nanny = available_nannies[selected_nanny - 1];

			Console.Write("\nCreating new contract between: {0} and {1} {2}\n", child.First_Name, nanny.First_Name, nanny.Family_Name);
			Contract cont = new Contract();
			cont.Child_Id = child.Id;
			cont.Mother_Id = mother.Id;
			cont.Nanny_Id = nanny.Id;
			bl.add_contract(cont);
			Console.Write("New contract between {0} and {1} {2} has been created. contract num is {3}\n", child.First_Name, nanny.First_Name, nanny.Family_Name, cont.Number);
			
		}

        private static void UpdatingContract(BL_imp bl)
        {
            Console.WriteLine("Enter the contract number  which you want to update");
            int number_update = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose which attribute to update");
            Console.WriteLine("1. The contract has been signed? Enter true of false");
            Console.WriteLine("2. Monthly salary");
            Console.WriteLine("3. Start date");
            Console.WriteLine("4. End date");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter true of false");
                    string signed = Console.ReadLine();
                    bl.update_contract(number_update, 1, signed.ToLower());
                    break;
                case 2:
                    Console.WriteLine("2. Enter the new montlhy salary");
                    double monthly_salary = double.Parse(Console.ReadLine());
                    bl.update_contract(number_update, 2, monthly_salary.ToString());
                    break;
                case 3:
                    Console.WriteLine("2. Enter the new starting date");
                    string start_date = Console.ReadLine();
                    bl.update_contract(number_update, 3, start_date);
                    break;
                case 4:
                    Console.WriteLine("2. Enter the new ending date");
                    string end_date = Console.ReadLine();
                    bl.update_contract(number_update, 4, end_date);
                    break;
            }
        }

        private static void UpdatingChild(BL_imp bl)
        {
            Console.WriteLine("Enter the child's id which you want to update");
            int id_update = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose which attribute to update");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Mother id");
            Console.WriteLine("3. First Name");
            Console.WriteLine("4. Has special needs?");
            Console.WriteLine("5. Birth date");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("Enter the new id");
                    int id = int.Parse(Console.ReadLine());
                    bl.update_child(id_update, 1, id.ToString());
                    break;
                case 2:
                    Console.WriteLine("Enter the new mother id");
                    int mother_id = int.Parse(Console.ReadLine());
                    bl.update_child(id_update, 2, mother_id.ToString());
                    break;
                case 3:
                    Console.WriteLine("Enter the new first name");
                    string first_name = Console.ReadLine();
                    bl.update_child(id_update, 3, first_name);
                    break;
                case 4:
                    Console.WriteLine("Enter if the child has special need? true or false");
                    string needs = Console.ReadLine();
                    string special_needs;
                    if (needs.ToLower() == "true")
                    {
                        Console.WriteLine("Which are the child's special needs?");
                        special_needs = Console.ReadLine();
                        bl.update_child(id_update, 4, needs, special_needs);
                    }
                    break;
                case 5:
                    Console.WriteLine("Enter the new birth date: enter dd/mm/yy");
                    string date = Console.ReadLine();
                    bl.update_nanny(id_update, 4, date);

                    break;
            }
        }
        private static void UpdatingMother(BL_imp bl)
        {
            Console.WriteLine("Enter the mother's id which you want to update");
            int id_update = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose which attribute to update");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. First Name");
            Console.WriteLine("3. Family Name");
            Console.WriteLine("4. Telephone Number");
            Console.WriteLine("5. Home adress");
            Console.WriteLine("6. Second address");
            Console.WriteLine("7. Distance the mother can travel");
            Console.WriteLine("8. The days and the hours she needs a nanny");
            Console.WriteLine("9. Comments");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("Enter the new id");
                    int id = int.Parse(Console.ReadLine());
                    bl.update_mother(id_update, 1, id.ToString());
                    break;
                case 2:
                    Console.WriteLine("Enter the new first name");
                    string first_name = Console.ReadLine();
                    bl.update_mother(id_update, 2, first_name);
                    break;
                case 3:
                    Console.WriteLine("Enter the new last name");
                    string last_name = Console.ReadLine();
                    bl.update_mother(id_update, 3, last_name);
                    break;
                case 4:
                    Console.WriteLine("Enter the new phone number");
                    string phonenumber = Console.ReadLine();
                    bl.update_mother(id_update, 4, phonenumber);
                 

                    break;
                case 5:
                    Console.WriteLine("Enter the new home address");
                    string home_address = Console.ReadLine();
                    bl.update_mother(id_update, 5, home_address);
                    break;
                case 6:
                    Console.WriteLine("Enter the new second address");
                    string second_address = Console.ReadLine();
                    bl.update_mother(id_update, 6, second_address);
                    break;
                case 7:
                    Console.WriteLine("Enter the new distance");
                    string distance = Console.ReadLine();
                    bl.update_mother(id_update, 7, distance);
                    break;
                case 8:
                    Console.WriteLine("Enter the new days and hours that the mother needs nanny:");
                    bool[] b = new bool[6];
                    TimeSpan[,] hours = new TimeSpan[6, 2];
                    for (int i = 0; i < 6; i++)
                    {
                        Week w = (Week)i + 1;
                        Console.Write("Dos she needs a nanny in ");
                        Console.Write(w);
                        Console.WriteLine("? Enter true or false");
                        b[i] = (Console.ReadLine().ToLower() == "true");
                        if (b[i])
                        {
                            Console.Write("Enter the hour she begins to work in ");
                            Console.Write(w);
                            Console.WriteLine("? Enter hh:mm");
                            hours[i, 0] = TimeSpan.Parse(Console.ReadLine());
                            Console.Write("Enter the hour she finishs to work in ");
                            Console.Write(w);
                            Console.WriteLine("? Enter hh:mm");
                            hours[i, 1] = TimeSpan.Parse(Console.ReadLine());
                        }
                    }
                    bl.update_mother(id_update, 8, b, hours);


                    break;
                case 9:
                    string coments = Console.ReadLine();
                    bl.update_mother(id_update, 9, coments);
                    break;

            }
        }
        private static void UpdatingNanny(BL_imp bl)
        {
            Console.WriteLine("Enter the nanny's id which you want to update");
            int id_update = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose which attribute to update");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. First Name");
            Console.WriteLine("3. Family Name");
            Console.WriteLine("4. Birth date");
            Console.WriteLine("5. Telephone Number");
            Console.WriteLine("6. Floor");
            Console.WriteLine("7. Experience years");
            Console.WriteLine("8. Number of children she can takes");
            Console.WriteLine("9. Maximum age of children she can takes");
            Console.WriteLine("10. Minimum age of children she can takes");
            Console.WriteLine("11. Hourly price exists?");
            Console.WriteLine("12. Update work days and work hours");
            Console.WriteLine("13. Elevator exists?");



            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("Enter the new id");
                    int id = int.Parse(Console.ReadLine());
                    bl.update_nanny(id_update, 1, id.ToString());
                    break;
                case 2:
                    Console.WriteLine("Enter the new first name");
                    string first_name = Console.ReadLine();
                    bl.update_nanny(id_update, 2, first_name);
                    break;
                case 3:
                    Console.WriteLine("Enter the new last name");
                    string last_name = Console.ReadLine();
                    bl.update_nanny(id_update, 3, last_name);
                    break;
                case 4:
                    Console.WriteLine("Enter the new birth date: enter dd/mm/yy");
                    
                    string date = Console.ReadLine();
                    bl.update_nanny(id_update, 4, date);
                    break;
                case 5:
                    Console.WriteLine("Enter the new phone number");
                    string phonenumber = Console.ReadLine();
                    bl.update_nanny(id_update, 5, phonenumber);
                    break;
                case 6:
                    Console.WriteLine("Enter the new floor number");
                    string floor = Console.ReadLine();
                    bl.update_nanny(id_update, 6, floor);
                    break;
                case 7:
                    Console.WriteLine("Enter the new number of experience years");
                    string experience = Console.ReadLine();
                    bl.update_nanny(id_update, 7, experience);
                    break;
                case 8:
                    Console.WriteLine("Enter the new max number of children she can takes ");
                    string max_children = Console.ReadLine();
                    bl.update_nanny(id_update, 8, max_children);
                    break;
                case 9:
                    Console.WriteLine("Enter the new max child age she can takes ");
                    string max_age = Console.ReadLine();
                    bl.update_nanny(id_update, 9, max_age);
                    break;
                case 10:
                    Console.WriteLine("Enter the new minimum child age she can takes ");
                    string min_age = Console.ReadLine();
                    bl.update_nanny(id_update, 10, min_age);
                    break;
                case 11:
                    Console.WriteLine("Enter the new hourly price ");
                    string hourly_price = Console.ReadLine();
                    bl.update_nanny(id_update, 11, hourly_price);
                    break;
                case 12:
                    Console.WriteLine("Enter the new work day and hours: ");
                    bool[] b = new bool[6];
                    TimeSpan[,] hours = new TimeSpan[6, 2];
                    for (int i = 0; i < 6; i++)
                    {
                        Week w = (Week)i + 1;
                        Console.Write("Dos she works in ");
                        Console.Write(w);
                        Console.WriteLine("? Enter true or false");
                        string s = Console.ReadLine();
                        if ((s.ToLower() == "true"))
                        {
                            b[i] = true;
                        }
                        else
                        {
                            b[i] = false;
                        }
                        if (b[i])
                        {
                            Console.Write("Enter the hour she begins to work in ");
                            Console.Write(w);
                            Console.WriteLine("? Enter hh:mm");
                            hours[i, 0] = TimeSpan.Parse(Console.ReadLine());
                            Console.Write("Enter the hour she finishs to work in ");
                            Console.Write(w);
                            Console.WriteLine("? Enter hh:mm");
                            hours[i, 1] = TimeSpan.Parse(Console.ReadLine());
                        }
                    }
                    bl.update_nanny(id_update, 12, b, hours);
                    break;
                case 13:
                    Console.WriteLine("Elevator exists? enter true or false ");
                    string elevator = Console.ReadLine();
                    bl.update_nanny(id_update, 13,elevator.ToLower());
                    break;
            }

        }
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
            n1.Work_Hours = new TimeSpan[2, 6] { {new TimeSpan(0,8,0), new TimeSpan(0,8,0), new TimeSpan(0,8,0), new TimeSpan(0,8,0), new TimeSpan(0,8,0), new TimeSpan(0,8,0)}
                                                ,{new TimeSpan(0,15,0), new TimeSpan(0,15,0), new TimeSpan(0,15,0), new TimeSpan(0,15,0), new TimeSpan(0,15,0), new TimeSpan(0,15,0)} };
            n1.Experience_Years = 1;
            n1.Lang = Language.YIDDISH;
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
            n2.Work_Hours = new TimeSpan[2, 6] { { new TimeSpan(0, 8, 30), new TimeSpan(0, 8, 30), new TimeSpan(0, 8, 30), new TimeSpan(0, 8, 30), new TimeSpan(0, 8, 30), new TimeSpan(0, 8, 30) } 
                                                ,{new TimeSpan(0,14,0), new TimeSpan(0,14,0), new TimeSpan(0,14,0), new TimeSpan(0,14,0), new TimeSpan(0,14,0), new TimeSpan(0,14,0)} };
            n2.Experience_Years = 3;
            n2.Lang = Language.YIDDISH;
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
            n3.Work_Hours = new TimeSpan[2, 6] { {new TimeSpan(0,7,15), new TimeSpan(0,7,15), new TimeSpan(0,7,15), new TimeSpan(0,7,15), new TimeSpan(0,7,15), new TimeSpan(0,7,15) }
                                                ,{new TimeSpan(0,17,0), new TimeSpan(0,17,0), new TimeSpan(0,17,0), new TimeSpan(0,17,0), new TimeSpan(0,17,0), new TimeSpan(0,17,0) } };
            n3.Experience_Years = 31;
            n3.Lang = Language.HEBREW;
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
            m1.Needs_Hours = new TimeSpan[2, 6] { {new TimeSpan(0,8,0), new TimeSpan(0,8,0), new TimeSpan(0,8,0), new TimeSpan(0,8,0), new TimeSpan(0,8,0), new TimeSpan(0,8,0)}
                                                ,{new TimeSpan(0,15,0), new TimeSpan(0,15,0), new TimeSpan(0,15,0), new TimeSpan(0,15,0), new TimeSpan(0,15,0), new TimeSpan(0,15,0)} };
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
            m2.Needs_Hours = new TimeSpan[2, 6] { {new TimeSpan(0,8,0), new TimeSpan(0,8,0), new TimeSpan(0,10,0), new TimeSpan(0,10,0), new TimeSpan(0,8,0), new TimeSpan(0,8,0)}
                                                ,{new TimeSpan(0,15,0), new TimeSpan(0,15,0), new TimeSpan(0,15,0), new TimeSpan(0,15,0), new TimeSpan(0,15,0), new TimeSpan(0,15,0)} };
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
            m3.Needs_Hours = new TimeSpan[2, 6] { {new TimeSpan(0,8,0), new TimeSpan(0,8,0), new TimeSpan(0,8,0), new TimeSpan(0,8,0), new TimeSpan(0,8,0), new TimeSpan(0,8,0)}
                                                ,{new TimeSpan(0,16,0), new TimeSpan(0,16,0), new TimeSpan(0,16,0), new TimeSpan(0,16,0), new TimeSpan(0,16,0), new TimeSpan(0,16,0) } };
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
            m4.Needs_Hours = new TimeSpan[2, 6] { {new TimeSpan(0,0,0), new TimeSpan(0,0,0), new TimeSpan(0,0,0), new TimeSpan(0,0,0), new TimeSpan(0,0,0), new TimeSpan(0,0,0)}
                                                ,{new TimeSpan(23,59,59), new TimeSpan(23,59,59), new TimeSpan(23,59,59), new TimeSpan(23,59,59), new TimeSpan(23,59,59), new TimeSpan(23,59,59)} };
            m4.Home_Address = "20 Malchei Yisrael, Jerusalem, Israel";
            m4.Telephone_Number = "02-544-9475";
            bl.add_mother(m4);
			#endregion

			#region mother 4 definition
			Mother m5 = new Mother();
			m5.Id = 339876879;
			m5.First_Name = "Nafta";
			m5.Family_Name = "Shluk";
			m5.Home_Address = "20 Malchei Yisrael, Jerusalem, Israel";
			m5.Max_Travel_Distance = 30;
			m5.Needs_On_Day = new bool[] { true, true, true, true, true, false, false };
			m5.Needs_Hours = new TimeSpan[2, 6] { {new TimeSpan(0,8,0), new TimeSpan(0,8,0), new TimeSpan(0,8,0), new TimeSpan(0,8,0), new TimeSpan(0,8,0), new TimeSpan(0,8,0)}
												,{new TimeSpan(0,15,0), new TimeSpan(0,15,0), new TimeSpan(0,15,0), new TimeSpan(0,15,0), new TimeSpan(0,15,0), new TimeSpan(0,15,0)} };
			m5.Home_Address = "20 Malchei Yisrael, Jerusalem, Israel";
			m5.Telephone_Number = "02-543-0781";
			bl.add_mother(m5);
			#endregion

		}

	}
}