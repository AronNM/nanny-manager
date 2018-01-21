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
{
    public class Dal_XML_imp
    {

        XElement managerRoot;
        string managerPath = @"ManagerXml.xml";
        #region xelement_&_files
        XElement Nannys;
        XElement Mothers;
        XElement Children;
        XElement Contracts;
       

        // bool flag = true;

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
        {
            if (n == null)
                return null;
            XElement nannyElement = new XElement("nanny");
            foreach (PropertyInfo item in typeof(Nanny).GetProperties())
                nannyElement.Add(new XElement(item.Name, item.GetValue(n, null)));
            return nannyElement;
        }

        Nanny convertXMLToNanny(XElement x)
        {
            if (x == null)
                return null;
            Nanny n = new Nanny();
            foreach (PropertyInfo item in typeof(Nanny).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = typeConverter.ConvertFromString(x.Element(item.Name).Value);
                item.SetValue(n, convertValue);
            }
            return n;
        }
        public Nanny GetNanny(long id)
        {
            return convertXMLToNanny((from e in Nannys.Elements()
                                        where Convert.ToInt64(e.Element("Id").Value) == id
                                        select e).FirstOrDefault());
        }
        public void add_nanny(Nanny n)
        {

            Nanny temp = new Nanny();
            temp = GetNanny(n.Id);
            if (temp != null)
                throw new Exception("This nanny already exist");
            Nannys.Add(convertNannyToXML(n));
            Nannys.Save(nannyXML);
        }

        public void remove_nanny(Nanny n)
        {

            XElement temp = ((from e in Nannys.Elements()
                              where (Convert.ToInt64(e.Element("Id").Value) == n.Id)
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This nanny not exist");
            temp.Remove();
            Nannys.Save(nannyXML);
        }

        public void update_nanny(Nanny n)
        {
            XElement temp = ((from e in Nannys.Elements()
                              where (Convert.ToInt64(e.Element("Id").Value) == n.Id)
                              select e).FirstOrDefault());
            if (temp == null)
                throw new Exception("This nanny not exist");
            temp.ReplaceWith(convertNannyToXML(n));
            Nannys.Save(nannyXML);
        }

        #endregion
        //public void SaveNannyList(List<Nanny> nannyList)
        //{
        //    nannyRoot = new XElement("nanny");

        //    foreach (Nanny item in nannyList)
        //    {
        //        XElement id = new XElement("id", item.Id);
        //        XElement firstName = new XElement("firstName", item.First_Name);
        //        XElement lastName = new XElement("lastName", item.Family_Name);

        //        XElement name = new XElement("name", firstName, lastName);
        //        XElement nanny = new XElement("nanny", id, name);

        //        nannyRoot.Add(nanny);

        //        add_Nanny(item);
        //    }

        //    nannyRoot.Save(nannyPath);
        //}
        //public List<Nanny> get_nanny_list()
        //{
        //    LoadData();
        //    List<Nanny> nannys;
        //    try
        //    {
        //        nannys = (from n in nannyRoot.Elements()
        //                    select new Nanny()
        //                    {
        //                        Id = int.Parse(n.Element("id").Value),
        //                        First_Name = n.Element("name").Element("firstName").Value,
        //                        Family_Name = n.Element("name").Element("lastName").Value
        //                    }).ToList();
        //    }
        //    catch
        //    {
        //        nannys = null;
        //    }
        //    return nannys;
        //}

        //public Nanny GetNanny(int id)
        //{
        //    LoadData();
        //   Nanny nanny;
        //    try
        //    {
        //        nanny = (from n in nannyRoot.Elements()
        //                   where int.Parse(n.Element("id").Value) == id
        //                   select new Nanny()
        //                   {
        //                       Id = int.Parse(n.Element("id").Value),
        //                       First_Name = n.Element("name").Element("firstName").Value,
        //                       Family_Name = n.Element("name").Element("lastName").Value
        //                   }).FirstOrDefault();
        //    }
        //    catch
        //    {
        //        nanny = null;
        //    }
        //    return nanny;
        //}

        //public string GetNannyName(int id)
        //{
        //    LoadData();
        //    string nannyName;
        //    try
        //    {
        //        nannyName = (from n in nannyRoot.Elements()
        //                       where int.Parse(n.Element("id").Value) == id
        //                       select n.Element("name").Element("firstName").Value
        //                       + " " +
        //                           n.Element("name").Element("lastName").Value
        //                            ).FirstOrDefault();
        //    }
        //    catch
        //    {
        //        nannyName = null;
        //    }
        //    return nannyName;
        //}

        //public void add_Nanny(Nanny nanny)
        //{
        //    XElement id = new XElement("id", nanny.Id);
        //    XElement firstName = new XElement("firstName", nanny.First_Name);
        //    XElement lastName = new XElement("lastName", nanny.Family_Name);
        //    XElement name = new XElement("name", firstName, lastName);

        //    nannyRoot.Add(new XElement("student", id, name));
        //    nannyRoot.Save(nannyPath);
        //}

        //public bool delete_nanny(Nanny nanny)
        //{
        //    XElement nannyElement;
        //    try
        //    {
        //        nannyElement = (from n in nannyRoot.Elements()
        //                        where int.Parse(n.Element("id").Value) == nanny.Id
        //                          select n).FirstOrDefault();
        //        nannyElement.Remove();
        //        nannyRoot.Save(nannyPath);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public void update_nanny(Nanny nanny)
        //{
        //    XElement studentElement = (from n in nannyRoot.Elements()
        //                               where int.Parse(n.Element("id").Value) == nanny.Id
        //                               select n).FirstOrDefault();

        //    studentElement.Element("name").Element("firstName").Value = nanny.First_Name;
        //    studentElement.Element("name").Element("lastName").Value = nanny.Family_Name;

        //    nannyRoot.Save(nannyPath);
        //}

    }
    
}
