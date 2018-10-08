using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_01
{
    public class Company
    {
        public IEnumerable<Department> Departments { get; }

        public string Name { get; set; }

        public Company() => Name = "";

        public Company(string name) => Name = name;

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
