using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfApp_01
{
    public class Employee
    {
        private Guid _ID;
        public Guid ID
        {
            get { return _ID; }
            private set { }
        }

        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        public string Position;
        public Department department;

        public Employee()
        {
            Name = "";
            Lastname = "";
            Patronymic = "";
            department = null;
            Position = "";
            _ID = System.Guid.NewGuid();
        }

        public Employee(string name, string ln, Department dp)
        {
            Name = name;
            Lastname = ln;
            department = dp;
            Patronymic = "";
            Position = "";
            _ID = System.Guid.NewGuid();
        }

        public Employee(string name, string ln, string pn)
        {
            Name = name;
            Lastname = ln;
            Patronymic = pn;
            Position = "";
            _ID = System.Guid.NewGuid();
        }

        public Employee(string name, string ln, string pn, Department dp)
        {
            Name = name;
            Lastname = ln;
            Patronymic = pn;
            department = dp;
            Position = "";
            _ID = Guid.NewGuid();
        }

        public override string ToString()
        {
            return (Patronymic == "") ? $"{department}: {Lastname} {Name}" : $"{department}: {Lastname} {Name} {Patronymic}";
        }
    }

}
