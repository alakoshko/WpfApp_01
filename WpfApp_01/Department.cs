using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_01
{
    public class Department : Company
    {
        public new string Name { get; set; }
        public Company Company { get; set; }

        public Department() {
            Name = "";
            Company = null;
        }

        public Department(Department d)
        {
            Name = d.Name;
            Company = d.Company;
        }

        public Department(string name)
        {
            Name = name;
            Company = null;
        }

        public Department(string name, Company company)
        {
            Name = name;
            Company = company;
        }
        public override string ToString()
        {
            return $"{Company} \\ {Name}";
        }
    }
}
