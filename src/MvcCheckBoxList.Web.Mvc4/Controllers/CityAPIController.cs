using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcCheckBoxList.Web.Mvc4.Model;

namespace MvcCheckBoxList.Web.Mvc4.Controllers
{
    public class CityAPIController : ApiController
    {

        private List<City> cities = new List<City>() { 
                    new City() { Id=1, Name="Norwich", IsSelected=false} ,
                    new City() { Id=2, Name="Cambridge", IsSelected=false} ,
                    new City() { Id=3, Name="London", IsSelected=false} };

        // GET api/cityapi
        public IEnumerable<City> Get()
        { 
            return cities;
        }

        // GET api/cityapi/5
        public City Get(int id)
        {
            return cities.Where(c => c.Id==id).FirstOrDefault();
        }

        // POST api/cityapi
        public City Post([FromBody]City value)
        {
            if(value.Id == 0 ){
                var MaxId = 0;
                foreach(var city in cities)
                {
                    if(city.Id > MaxId)
                    {
                        MaxId = city.Id;
                    }
                }
                value.Id = MaxId + 1;
            }
            cities.Add(value);
            return value;
        }

        // PUT api/cityapi/5
        public City Put(int id, [FromBody]City value)
        {
            var city = cities.Where(c => c.Id == id).FirstOrDefault();
            city.Name = value.Name;
            return city;
        }

        // DELETE api/cityapi/5
        public void Delete(int id)
        { 
            cities.Remove(cities.Find(c => c.Id == id));
        }
    }
}
