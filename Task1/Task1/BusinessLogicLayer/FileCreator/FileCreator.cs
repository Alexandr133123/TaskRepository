using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Task1.DBLayer.DbCall;
using Task1.DBLayer.Model;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.IO;


namespace Task1.BusinessLogicLayer.FileCreator
{
    class FileCreator
    {
        DbOperations db;

       public FileCreator()
        {
            
            Directory.CreateDirectory(@"../../../FileContainer/txt");

            Directory.CreateDirectory(@"../../../FileContainer/xml");

            Directory.CreateDirectory(@"../../../FileContainer/json");

            db = new DbOperations();
  
        }

        public void CreateXml()
        {
            WriteXmlFile(db.GetAllPeople());
        }

        public void CreateJson()
        {
            using (StreamWriter tw = new StreamWriter(@"../../../FileContainer/txt/Person.json", false))
            {

                tw.WriteLine(JsonConvert.SerializeObject(db.GetAllPeople(), new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

                    Formatting = Formatting.Indented,

                    NullValueHandling = NullValueHandling.Ignore,

                    DefaultValueHandling = DefaultValueHandling.Ignore

                }));

                tw.Close();


            }
        }

        
        public void CreateTxt()
        {
            PrintTxt();
        }


        private void PrintTxt()
        {

            StringBuilder text = new StringBuilder("");

            using (StreamWriter tw = new StreamWriter(@"../../../FileContainer/txt/Person.txt", false))
            {

                PrintChildTxt(db.GetAllPeople(), text, tw);

                tw.Close();
            }
        }

        private void PrintChildTxt(IEnumerable<Person> people, StringBuilder temp, StreamWriter tw)
        {

            
            foreach (Person p in  people)
            {

                if (p.InverseFkParentPerson != null)
                {

                    temp.Append(p.PersonName + $"({ p.PkPersonId})");

                    tw.WriteLine(temp);

                    temp.Append("---");
                    
                    PrintChildTxt(p.InverseFkParentPerson, temp, tw);
                }
                else
                {

                    tw.WriteLine(p.PersonName + $"({p.PkPersonId})\n");

                    

                }

                temp.Replace("---"+p.PersonName + $"({p.PkPersonId})", "");
            }

           
            
        }

        private void WriteXmlFile(IEnumerable<Person> people)
        {

            XDocument xDoc = new XDocument();

            XElement xRoot = new XElement("root");

            foreach (Person p in people)
            {

                XElement xNode = new XElement("node");

                XAttribute xId = new XAttribute("id", p.PkPersonId);

                XElement xName = new XElement("name", p.PersonName);

                xNode.Add(xId, xName);

                if (p.InverseFkParentPerson.Count != 0)
                {

                    xNode.Add(WriteXmlChild(p));

                }

                xRoot.Add(xNode);



            }

            xDoc.Add(xRoot);

            xDoc.Save(@"../../../FileContainer/txt/person.xml");
        }

         private XElement WriteXmlChild(Person person)
         {
                XElement xChildren = new XElement("children");

                foreach (Person ch in person.InverseFkParentPerson)
                {

                    XElement xNode = new XElement("node");

                    XAttribute xId = new XAttribute("id", ch.PkPersonId);

                    XElement xName = new XElement("name", ch.PersonName);

                    xNode.Add(xId, xName);

                    if (ch.InverseFkParentPerson.Count != 0)
                    {

                        xNode.Add(WriteXmlChild(ch));

                    }

                    xChildren.Add(xNode);

                }


                return xChildren;
          }





    }
}
