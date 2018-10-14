using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfApp_01
{
    public class Department : ViewModel
    {
        private Guid _ID;
        public Guid ID
        {
            get { return _ID; }
            set => Set(ref _ID, value);
        }

        private string deptname;
        public string DeptName
        {
            get => deptname;
            set => Set(ref deptname, value);
        }

        private Guid companyID;
        public Guid CompanyID
        {
            get => companyID;
            set => Set(ref companyID, value);
        }

        private Company company;
        public Company Company
        {
            get => company;
            set => Set(ref company, value);
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
