using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections;
using Newtonsoft.Json.Linq;
using mitraisBiz;
using mitraisBiz.Entities;

namespace mitraisWeb.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public IList<User> Get()
        {
            DataManager objDataManager = new DataManager();
            return objDataManager.UserList();
        }

        // GET: api/User/5
        public IList<User> Get(int id)
        {
            DataManager objDataManager = new DataManager();
            return objDataManager.UserDetail(id);
        }

        // POST: api/User
        public Hashtable Post([FromBody] JObject UserData)
        {
            Hashtable result = new Hashtable();
            try
            {
                int Id = 0;

                DataManager objDataManager = new DataManager();
                Id = objDataManager.AddUser(UserData);

                result.Add("status", "ok");
                result.Add("data", Id);

            }
            catch (Exception e)
            {
                result.Add("status", "error");
                result.Add("data", e.Message);
            }
            return result;

        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
