using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Business
{
    public class PersonBusiness
    {
        public List<Product> Get()
        {
            PersonData data = new PersonData();
            var people = data.Get();
            return people;
        }

        public List<Product> Get18(string productName)
        {
            PersonData data = new PersonData();
            var people = data.Get();
            var result = people.Where(x => x.name.Contains(productName)).ToList();
            return result;
        }

        public void Insert(Product product)
        {
            PersonData data = new PersonData();
            data.Insert(product);
            
        }

        public void Update(Product product)
        {
            PersonData data = new PersonData();
            data.Update(product);
        }

        public void Delete(int productId)
        {
            PersonData data = new PersonData();
            data.Delete(productId);
        }


    }
}
