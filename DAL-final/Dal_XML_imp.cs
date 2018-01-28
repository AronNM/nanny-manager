using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL_final
{//This class manages the Xml files, write the created objects in the Xml files, and convert the files data to objects
    public class Dal_XML_imp
    {

        XElement managerRoot;
        string managerPath = @"ManagerXml.xml";
        #region xelement_&_files
        XElement Nannys;
        XElement Mothers;
        XElement Children;
        XElement Contracts;



        string nannyXML = @"nanny.xml";
        string motherXML = @"motherXML.xml";
        string childXML = @"childXML.xml";
        string contractXML = @"contractXML.xml";

        #endregion

        public Dal_XML_imp()
        {
            if (!File.Exists(managerPath))
                CreateFiles();
            else
                LoadData();
        }
        private void CreateFiles()
        {
            managerRoot = new XElement("Manager");
            managerRoot.Save(managerPath);

            Nannys = new XElement("nannys");
            Nannys.Save(nannyXML);

            Mothers = new XElement("mothers");
            Mothers.Save(motherXML);

            Children = new XElement("children");
            Children.Save(childXML);

            Contracts = new XElement("contracts");
            Contracts.Save(contractXML);
        }
        private void LoadData()
        {
            try
            {
                Nannys = XElement.Load(nannyXML);
                Mothers = XElement.Load(motherXML);
                Contracts = XElement.Load(contractXML);
                Children = XElement.Load(childXML);
                managerRoot = XElement.Load(managerPath);


            }
            catch
            {
                throw new Exception(" loaded file fail!");
            }
        }
        #region Nannys
        XElement convertNannyToXML(Nanny n)
        {//this function writes a nanny object in a Xml file
            if (n == null)
                return null;
            XElement nannyElement = new XElement("nanny");
            foreach (PropertyInfo item in typeof(Nanny).GetProperties())
            {
                string day;
                string work;
                string language;
                //in order to write the boolean array ,the TimeSpan to the Xml file, or the Enum array
                //we must to write every array member manually

                //if this is not a "problematic" property, we can convert automatically to Xml
                if (item.PropertyType.Name != "Boolean[]" && item.PropertyType.Name != "TimeSpan[,]" && item.PropertyType.Name != "List`1")
                {
                    nannyElement.Add(new XElement(item.Name, item.GetValue(n, null)));
                }
                else
                {
                    if (item.PropertyType.Name == "Boolean[]")
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            day = "Day" + (i + 1);
                            nannyElement.Add(new XElement(day, n.Works_On_Day[i]));
                        }
                    }
                    if (item.PropertyType.Name == "TimeSpan[,]")
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            work = "WorkStarts" + (i + 1);
                            nannyElement.Add(new XElement(work, n.Work_Hours[i,0]));
                            work = "WorkEnds" + (i + 1);
                            nannyElement.Add(new XElement(work, n.Work_Hours[i,1]));
                        }
                    }
                    //In case of Enum
                    if (item.PropertyType.Name == "List`1")
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            language = "Language" + (i + 1);
                            if (i < n.Lang.Count)
                            {
                                nannyElement.Add(new XElement(language, n.Lang[i]));
                            }
                            else
                            {
                                nannyElement.Add(new XElement(language));
                            }
                        }
                    }

                }
            }

            return nannyElement;
        }

        Nanny convertXMLToNanny(XElement x)
        {//this function converts the Xml file to a nanny object
            if (x == null)
                return null;
            Nanny n = new Nanny();
            foreach (PropertyInfo item in typeof(Nanny).GetProperties())
            {

                
                object convertValue;
                string day;
                string time;
                //if this is not a bool array property, or TimeSpan array property, or a Enum array property
                //we can convert automatically
                if (item.PropertyType.Name != "Boolean[]" && item.PropertyType.Name != "TimeSpan[,]" && item.PropertyType.Name != "List`1")
                {
                    TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                    convertValue = typeConverter.ConvertFromString(x.Element(item.Name).Value);
                    item.SetValue(n, convertValue);
                }
                else
                {
                    if (item.PropertyType.Name == "Boolean[]")
                    {
                        TypeConverter boolconverter = TypeDescriptor.GetConverter("Bool");
                        for (int i = 0; i < 6; i++)
                        {
                            day = "Day" + (i + 1);
                            convertValue = boolconverter.ConvertFromString(x.Element(day).Value);
                            if (convertValue.ToString() == "true")
                            {
                                n.Works_On_Day[i] = true;
                            }
                            if (convertValue.ToString() == "false")
                            {
                                n.Works_On_Day[i] = false;
                            }
                        }

                    }
                    if (item.PropertyType.Name == "TimeSpan[,]")
                    {//The TimeSpan is saved like"PT8H30M", so we must convert to a number that TimeSpan can receive
                        TypeConverter timeconverter = TypeDescriptor.GetConverter("TimeSpan");
                        for (int i = 0; i < 6; i++)
                        {
                            time = "WorkStarts" + (i + 1);
                            convertValue = timeconverter.ConvertFromString(x.Element(time).Value);
                            string hour = (convertValue.ToString()).Replace("H", ":");
                            hour = hour.Remove(0, 2);

                            if (hour.EndsWith(":"))
                            {
                                hour += "00";
                            }
                            if (hour.EndsWith("M"))
                            {
                                hour = hour.Substring(0, hour.Length - 1);
                            }
                            if (hour.EndsWith("S"))
                            {
                                if (!(hour == "0S"))
                                {
                                    hour.Replace("M", ":");
                                    hour = hour.Substring(0, hour.Length - 1);
                                }
                                else hour = "00:00";
                            }
                            n.Work_Hours[i, 0] = TimeSpan.Parse(hour);
                            time = "WorkEnds" + (i + 1);
                            convertValue = timeconverter.ConvertFromString(x.Element(time).Value);
                            hour = (convertValue.ToString()).Replace("H", ":");
                            hour = hour.Remove(0, 2);

                            if (hour.EndsWith(":"))
                            {
                                hour += "00";
                            }
                            if (hour.EndsWith("M"))
                            {
                                hour = hour.Substring(0, hour.Length - 1);
                            }
                            if (hour.EndsWith("S"))
                            {
                                if (!(hour == "0S"))
                                {
                                    hour.Replace("M", ":");
                                    hour = hour.Substring(0, hour.Length - 1);
                                }
                                else hour = "00:00";
                            }

                            n.Work_Hours[i, 1] = TimeSpan.Parse(hour);
                        }

                    }
                    //if this is a Enum array property
                    if (item.PropertyType.Name == "List`1")
                    {
                        TypeConverter langconverter = TypeDescriptor.GetConverter("Language");
                        string lang;
                        for (int i = 0; i < 5; i++)
                        {
                            lang = "Language" + (i + 1);
                            if (!x.Element(lang).IsEmpty)
                            {
                                convertValue = langconverter.ConvertFromString(x.Element(lang).Value);
                                n.Lang.Add((Language)Enum.Parse(typeof(Language), convertValue.ToString()));
                            }


                        }
                    }

                }

            }
            return n;
        }
        public Nanny GetNanny(long id)
        {//this fuction returns a nanny by its Id
            return convertXMLToNanny((from e in Nannys.Elements()
                                      where Convert.ToInt64(e.Element("Id").Value) == id
                                      select e).FirstOrDefault());
        }
        public void add_nanny(Nanny n)
        {//This function receives a nanny object, check if this nanny already exists in the data
            // and adds it, in case that is a new nanny

            Nanny temp = new Nanny();
            temp = GetNanny(n.Id);
            if (temp != null)
                throw new Exception("This nanny already exist");
            Nannys.Add(convertNannyToXML(n));
            Nannys.Save(nannyXML);
        }

        public void delete_nanny(Nanny n)
        {//This function receives a nanny object, check if this nanny already exists in the data
            // and delete it, in case that is a existent nanny

            XElement temp = ((from e in Nannys.Elements()
                              where (Convert.ToInt64(e.Element("Id").Value) == n.Id)
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This nanny not exist");
            temp.Remove();
            Nannys.Save(nannyXML);
        }

        public void update_nanny(Nanny n,int id)
        {//This function receives a nanny object, check if this nanny already exists in the data
            // and replace it, in case that is a existent nanny
            XElement temp = ((from e in Nannys.Elements()
                              where (Convert.ToInt64(e.Element("Id").Value) == id)
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This nanny not exist");
            temp.ReplaceWith(convertNannyToXML(n));
            Nannys.Save(nannyXML);
        }

        #endregion

        #region Mothers

        XElement convertMotherToXML(Mother m)
        {//this function writes a mother object in a Xml file
            if (m == null)
                return null;
            XElement motherElement = new XElement("mother");
            foreach (PropertyInfo item in typeof(Mother).GetProperties())
            {
                string day;
                string work;
                
                //in order to write the boolean array ,the TimeSpan to the Xml file
                //we must to write every array member manually

                //if this is not a "problematic" property, we can convert automatically to Xml
                if (item.PropertyType.Name != "Boolean[]" && item.PropertyType.Name != "TimeSpan[,]")
                {
                    motherElement.Add(new XElement(item.Name, item.GetValue(m, null)));
                }
                else
                {
                    if (item.PropertyType.Name == "Boolean[]")
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            day = "Day" + (i + 1);
                            motherElement.Add(new XElement(day, m.Needs_On_Day[i]));
                        }
                    }
                    if (item.PropertyType.Name == "TimeSpan[,]")
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            work = "NeedsStarts" + (i + 1);
                            motherElement.Add(new XElement(work, m.Needs_Hours[i,0]));
                            work = "NeedsEnds" + (i + 1);
                            motherElement.Add(new XElement(work, m.Needs_Hours[i,1]));
                        }
                    }


                }
            }

            return motherElement;
        }

        Mother convertXMLToMother(XElement x)
        {//this function converts the Xml file to a mother object
            if (x == null)
                return null;
            Mother m = new Mother();
            foreach (PropertyInfo item in typeof(Mother).GetProperties())
            {

                
                object convertValue;
                string day;
                string time;
                //if this is not a bool array property, or TimeSpan array property
                //we can convert automatically
                if (item.PropertyType.Name != "Boolean[]" && item.PropertyType.Name != "TimeSpan[,]")
                {
                    TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                    convertValue = typeConverter.ConvertFromString(x.Element(item.Name).Value);
                    item.SetValue(m, convertValue);
                }
                else
                {
                    if (item.PropertyType.Name == "Boolean[]")
                    {
                        TypeConverter boolconverter = TypeDescriptor.GetConverter("Bool");
                        for (int i = 0; i < 6; i++)
                        {
                            day = "Day" + (i + 1);
                            convertValue = boolconverter.ConvertFromString(x.Element(day).Value);
                            if (convertValue.ToString() == "true")
                            {
                                m.Needs_On_Day[i] = true;
                            }
                            if (convertValue.ToString() == "false")
                            {
                                m.Needs_On_Day[i] = false;
                            }
                        }

                    }
                    if (item.PropertyType.Name == "TimeSpan[,]")
                    {//The TimeSpan is saved like"PT8H30M", so we must convert to a number that TimeSpan can receive
                        TypeConverter timeconverter = TypeDescriptor.GetConverter("TimeSpan");
                        for (int i = 0; i < 6; i++)
                        {
                            time = "NeedsStarts" + (i + 1);
                            convertValue = timeconverter.ConvertFromString(x.Element(time).Value);
                            string hour = (convertValue.ToString()).Replace("H", ":");
                            hour = hour.Remove(0, 2);

                            if (hour.EndsWith(":"))
                            {
                                hour += "00";
                            }
                            if (hour.EndsWith("M"))
                            {
                                hour = hour.Substring(0, hour.Length - 1);
                            }
                            if(hour.EndsWith("S"))
                            {
                                if (!(hour == "0S"))
                                {
                                    hour.Replace("M", ":");
                                    hour = hour.Substring(0, hour.Length - 1);
                                }
                                else hour = "00:00";
                            }
                            m.Needs_Hours[i, 0] = TimeSpan.Parse(hour);
                            time = "NeedsEnds" + (i + 1);
                            convertValue = timeconverter.ConvertFromString(x.Element(time).Value);
                            hour = (convertValue.ToString()).Replace("H", ":");
                            hour = hour.Remove(0, 2);

                            if (hour.EndsWith(":"))
                            {
                                hour += "00";
                            }
                            if (hour.EndsWith("M"))
                            {
                                hour = hour.Substring(0, hour.Length - 1);
                            }
                            if (hour.EndsWith("S"))
                            {
                                if (!(hour == "0S"))
                                {
                                    hour=hour.Replace("M", ":");
                                    
                                    hour = hour.Substring(0, hour.Length - 1);
                                }
                                else hour = "00:00";
                            }

                            m.Needs_Hours[i, 1] = TimeSpan.Parse(hour);
                        }

                    }

                }

            }
            return m;
        }
        public Mother GetMother(long id)
        {//this fuction returns a mother by its Id
            return convertXMLToMother((from e in Mothers.Elements()
                                       where Convert.ToInt64(e.Element("Id").Value) == id
                                       select e).FirstOrDefault());
        }
        public void add_mother(Mother m)
        {//This function receives a mother object, check if this mother already exists in the data
            // and adds it, in case that is a new mother

            Mother temp = new Mother();
            temp = GetMother(m.Id);
            if (temp != null)
                throw new Exception("This nanny already exist");
            Mothers.Add(convertMotherToXML(m));
            Mothers.Save(motherXML);
        }

        public void delete_mother(Mother m)
        {//This function receives a mother object, check if this mother already exists in the data
            // and deletes it, in case that is a existent mother

            XElement temp = ((from e in Mothers.Elements()
                              where (Convert.ToInt64(e.Element("Id").Value) == m.Id)
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This mother not exist");
            temp.Remove();
            Mothers.Save(motherXML);
        }

        public void update_mother(Mother m,int id)
        {//This function receives a mother object, check if this mother already exists in the data
            // and replaces it, in case that is a existent mother
            XElement temp = ((from e in Mothers.Elements()
                              where (Convert.ToInt64(e.Element("Id").Value) == id)
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This nanny not exist");
            temp.ReplaceWith(convertMotherToXML(m));
            Mothers.Save(motherXML);
        }
        #endregion

        #region Children
        XElement convertChildToXML(Child c)
        {//this function writes a child object in a Xml file
            if (c == null)
                return null;
            XElement childElement = new XElement("child");
            foreach (PropertyInfo item in typeof(Child).GetProperties())
            {
                childElement.Add(new XElement(item.Name, item.GetValue(c, null)));
            }

            return childElement;
        }

        Child convertXMLToChild(XElement x)
        {//this function converts the Xml file to a child object
            if (x == null)
                return null;
            Child c = new Child();
            foreach (PropertyInfo item in typeof(Child).GetProperties())
            {
                object convertValue;
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                convertValue = typeConverter.ConvertFromString(x.Element(item.Name).Value);
                item.SetValue(c, convertValue);
            }
            return c;
        }
        public Child GetChild(long id)
        {//this fuction returns a child by its Id
            return convertXMLToChild((from e in Children.Elements()
                                      where Convert.ToInt64(e.Element("Id").Value) == id
                                      select e).FirstOrDefault());
        }
        public void add_child(Child c)
        {//This function receives a child object, check if this child already exists in the data
            // and adds it, in case that is a new child

            Child temp = new Child();
            temp = GetChild(c.Id);
            if (temp != null)
                throw new Exception("This child already exist");
            Children.Add(convertChildToXML(c));
            Children.Save(childXML);
        }

        public void delete_child(Child c)
        {//This function receives a child object, check if this child already exists in the data
            // and deletes it, in case that is a existent child

            XElement temp = ((from e in Children.Elements()
                              where (Convert.ToInt64(e.Element("Id").Value) == c.Id)
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This child not exist");
            temp.Remove();
            Children.Save(childXML);
        }

        public void update_child(Child c,int id)
        {//This function receives a child object, check if this child already exists in the data
            // and updates it, in case that is a existent child
            XElement temp = ((from e in Children.Elements()
                              where (Convert.ToInt64(e.Element("Id").Value) == id)
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This child not exist");
            temp.ReplaceWith(convertChildToXML(c));
            Children.Save(childXML);
        }
        #endregion

        #region contract
        XElement convertContractToXML(Contract c)
        {//this function writes a contract object in a Xml file
            if (c == null)
                return null;
            XElement contractElement = new XElement("contract");
            foreach (PropertyInfo item in typeof(Contract).GetProperties())
            {
                contractElement.Add(new XElement(item.Name, item.GetValue(c, null)));
            }

            return contractElement;
        }

        Contract convertXMLToContract(XElement x)
        {//this function converts the Xml file to a contract object
            if (x == null)
                return null;
            Contract c = new Contract();
            foreach (PropertyInfo item in typeof(Contract).GetProperties())
            {
                object convertValue;
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                convertValue = typeConverter.ConvertFromString(x.Element(item.Name).Value);
                item.SetValue(c, convertValue);
            }
            return c;
        }
        public Contract GetContract(long id)
        {//this fuction returns a contract by its Id
            return convertXMLToContract((from e in Contracts.Elements()
                                         where Convert.ToInt64(e.Element("Number").Value) == id
                                         select e).FirstOrDefault());
        }
        public void add_contract(Contract c)
        {//This function receives a contract object, check if this contract already exists in the data
            // and adds it, in case that is a new contract

            Contract temp = new Contract();
            temp = GetContract(c.Number);
            if (temp != null)
                throw new Exception("This contract already exist");
            Contracts.Add(convertContractToXML(c));
            Contracts.Save(contractXML);
        }

        public void delete_contract(Contract c)
        {//This function receives a contract object, check if this contract already exists in the data
            // and deletes it, in case that is a existent contract

            XElement temp = ((from e in Contracts.Elements()
                              where (Convert.ToInt64(e.Element("Number").Value) == c.Number)
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This contract not exist");
            temp.Remove();
            Contracts.Save(contractXML);
        }

        public void update_contract(Contract c,int id)
        {//This function receives a contract object, check if this contract already exists in the data
            // and updates it, in case that is a existent contract
            XElement temp = ((from e in Contracts.Elements()
                              where (Convert.ToInt64(e.Element("Number").Value) == id)
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This contract not exist");
            temp.ReplaceWith(convertContractToXML(c));
            Contracts.Save(contractXML);

        }
        #endregion

        #region GetList
        public List<Nanny> get_nanny_list()
        {//Convert all the Nannys in the xml file to a List
            List<Nanny> ListNanny = new List<Nanny>();
            var items = from temp in Nannys.Elements()
                        select convertXMLToNanny(temp);
            ListNanny = items.ToList();
            return ListNanny;

        }

        public List<Mother> get_mother_list()
        {//Convert all the Mothers in the xml file to a List
            List<Mother> ListMother = new List<Mother>();
            var items = from temp in Mothers.Elements()
                        select convertXMLToMother(temp);
            ListMother = items.ToList();
            return ListMother;

        }
        public List<Child> get_child_list()
        {//Convert all the Children in the xml file to a List
            List<Child> ListChildren = new List<Child>();
            var items = from temp in Children.Elements()
                        select convertXMLToChild(temp);
            ListChildren = items.ToList();
            return ListChildren;

        }
        public List<Contract> get_contract_list()
        {//Convert all the Contracts in the xml file to a List
            List<Contract> ListContract = new List<Contract>();
            var items = from temp in Contracts.Elements()
                        select convertXMLToContract(temp);
            ListContract = items.ToList();
            return ListContract;

        }




        #endregion
    }
}
