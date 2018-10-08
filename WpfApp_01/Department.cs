using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfApp_01
{
    public class Department
    {
        private ObservableCollection<Employee> _Employes = new ObservableCollection<Employee>();

        public string Name { get; set; }
        //public Company Company { get; set; }

        /// <summary>Работники отдела</summary>
        public IEnumerable<Employee> Employes => _Employes;

        public Department() {
            Name = "";
            //Company = null;
        }

        public Department(Department d)
        {
            Name = d.Name;
            //Company = d.Company;
        }

        public Department(string name)
        {
            Name = name;
            //Company = null;
        }

        public override string ToString()
        {
            return $"{Name}";
            //return $"{Company} \\ {Name}";
        }
    }
}
