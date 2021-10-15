using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Task1.DBLayer.DB;
using Task1.DBLayer.Model;

namespace Task1.DBLayer.DbCall
{
    class DbOperations 
    {
        private InternshipContext db;

        public DbOperations()
        {
            db = new InternshipContext();
            db.ChangeTracker.AutoDetectChangesEnabled = false;
        }


        public List<Person> GetAllPeople()
        {
            return (List<Person>)BuildTree(db.People.ToList());
  
        }


        private IList<Person> BuildTree(IEnumerable<Person> source )
        {

            var groups = source.OrderBy(i => i.PersonName).GroupBy(i => i.FkParentPersonId);

            var roots = groups.FirstOrDefault(g => g.Key == null).OrderBy(root => root.PersonName).ToList();

            if (roots.Count > 0)
            {
                var dict = groups.Where(g => g.Key != null).ToDictionary(g => g.Key, g => g.ToList());
                for (int i = 0; i < roots.Count; i++)
                {
                    
                    AddChildren(roots[i], dict);

                }
            }

            return roots;
        }

        private void AddChildren(Person person, IDictionary<int?, List<Person>> source)
        {
            

            if (source.ContainsKey(person.PkPersonId))
            {
                
                person.InverseFkParentPerson = source[person.PkPersonId];
                for (int i = 0; i < person.InverseFkParentPerson.Count; i++)
                    AddChildren(person.InverseFkParentPerson[i], source);
            }
            else
            {
                person.InverseFkParentPerson = new List<Person>();
            }
        }


    }
}
