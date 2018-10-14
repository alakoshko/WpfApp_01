using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfApp_01
{
    public class Department : ViewModel
    {
        private string deptname;
        public string DeptName
        {
            get => deptname;
            set => Set(ref deptname, value);
        }

        public Department(Department d) => DeptName = d.deptname;

        public Department(string deptname) => DeptName = deptname;
        public Department() { }

        public override string ToString()
        {
            return $"{DeptName}";
            //return $"{Company} \\ {Name}";
        }
    }
}
