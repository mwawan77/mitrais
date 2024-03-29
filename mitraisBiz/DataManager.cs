﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using NHibernate.Criterion;
using Newtonsoft.Json.Linq;
using mitraisBiz;
using mitraisBiz.Entities;

namespace mitraisBiz
{
    public class DataManager
    {
        public DataManager()
        {
            SetConnection();
        }

        public int AddUser(JObject UserData)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        User UserObj = UserData.ToObject<User>();

                        // Check Mobile Number
                        IList<User> MobileCheck = session.CreateCriteria<User>()
                           .Add(Restrictions.Eq("MobileNumber", UserObj.MobileNumber))
                           .List<User>();

                        if (MobileCheck.Count > 0)
                        {
                            throw new ApplicationException("Mobile Number exist on database");
                        }

                        // Check Email
                        IList<User> EmailCheck = session.CreateCriteria<User>()
                           .Add(Restrictions.Eq("Email", UserObj.Email))
                           .List<User>();

                        if (EmailCheck.Count > 0)
                        {
                            throw new ApplicationException("Email exist on database");
                        }

                        User objUser = new User
                        {
                            MobileNumber = UserObj.MobileNumber,
                            FirstName = UserObj.FirstName,
                            LastName = UserObj.LastName,
                            DateOfBirth = Convert.ToDateTime(UserObj.DateOfBirth),
                            Sex = UserObj.Sex,
                            Email = UserObj.Email,
                            Password = UserObj.Password,
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Wawan",
                            UpdatedDate = DateTime.Now,
                            UpdatedBy = "Wawan"
                        };

                        session.Save(objUser);
                        transaction.Commit();

                        return objUser.Id;

                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<User> UserList()
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        //return session.Query<User>().ToList();
                        IList<User> EmailCheck = session.CreateCriteria<User>()
                           .Add(Restrictions.Eq("Email", "mwawan@yahoo.com"))
                           .List<User>();

                        return EmailCheck;
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<User> UserDetail(int Id)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        IList<User> UserList = session.CreateCriteria<User>()
                           .Add(Restrictions.Eq("Id", Id))
                           .List<User>();

                        return UserList;
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetConnection()
        {
            NHibernateHelper objNHibernate = new NHibernateHelper
            {
                Connection = ConfigurationManager.ConnectionStrings["mitraisDb"].ConnectionString
            };
        }

    }
}
