using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_01
{
    public class Company
    {
        private ObservableCollection<Department> _Depts = new ObservableCollection<Department>();

        public IEnumerable<Department> Departments => _Depts;

        public string Name { get; set; }

        public Company() {
            Name = "";
            _Depts.Add(new Department { Name= "FrontOffice" });
            _Depts.Add(new Department { Name = "BackOffice" });
        }

        public Company(string name) => Name = name;

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
