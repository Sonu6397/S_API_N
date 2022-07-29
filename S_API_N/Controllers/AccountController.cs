using S_API_N.API_connt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace S_API_N.Controllers
{
    public class AccountController : ApiController
    {
        [Route("Account/Index")]
        public List<Employee> Getname()
        {
            dummyEntities db = new dummyEntities();
            var res = db.Employees.ToList();
            return res;
        }
        [HttpPost]
        [Route("Account/Create")]

        public HttpResponseMessage Create(Employee b)
        {
            HttpResponseMessage ap = new HttpResponseMessage();
            dummyEntities db = new dummyEntities();
            db.Employees.Add(b);
            db.SaveChanges();
            return ap;
        }
        [HttpGet]
        [Route("Account/GetEdit")]
        public Employee Edit(int id)
        {
            dummyEntities db = new dummyEntities();
            var Et = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            return Et;
        }

        [HttpPut]
        [Route("Account/PostEdit")]

        public HttpResponseMessage Edit(Employee d)
        {
            HttpResponseMessage ap = new HttpResponseMessage();
            dummyEntities db = new dummyEntities();
            db.Entry(d).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return ap;
        }
        [HttpGet]
        [Route("Account/Delete")]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage ap = new HttpResponseMessage();
            dummyEntities db = new dummyEntities();
            var dt = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            db.Employees.Remove(dt);
            db.SaveChanges();
            return ap;
        }
       
    }
     
}
