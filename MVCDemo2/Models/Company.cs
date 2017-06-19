using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo2.Models
{
    public class Company
    {
        private string _name;
        public Company(string name)
        {
            this._name = name;
        }
        public List<Department> Departments
        {
            get
            {
                Sample3Entities db = new Sample3Entities();
                return db.Departments.ToList();
            }
        }

        public string CompanyName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

    }
}