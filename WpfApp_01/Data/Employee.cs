using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApp_01
{
    public class Employee : ViewModel
    {

        #region поля класса
        private Guid _ID;
        public Guid ID
        {
            get { return _ID; }
            set => Set(ref _ID, value);
        }

        private Guid _DeptID;
        public Guid DeptID
        {
            get { return _DeptID; }
            set => Set(ref _DeptID, value);
        }

        private Guid _PositionID;
        public Guid PositionID
        {
            get { return _PositionID; }
            set => Set(ref _PositionID, value);
        }

        private string birthday;
        public string Birthday
        {
            get => birthday;
            set => Set(ref birthday, value);
        }

        private string name;
        public string Name {
            get => name;
            set => Set(ref name, value);
        }

        private string lastname;
        public string Lastname {
            get => lastname;
            set => Set(ref lastname, value);
        }

        private string patronymic;
        public string Patronymic { get => patronymic;
            set => Set(ref patronymic, value);
        }

        private int age;
        public int Age { get => age;
            set => Set(ref age, value);
        }

        private double salary;
        public double Salary { get => salary;
            set => Set(ref salary, value);
        }

        private string position;
        public string Position
        {
            get => position;
            set => Set(ref position, value);
        }
        
        private Department department;
        public Department Dept
        {
            get => department;
            set => Set(ref department, value);
        }
        #endregion 

        public Employee()
        {
            Name = "";
            Lastname = "";
            Patronymic = "";
            department = null;
            Position = "";
            _ID = System.Guid.NewGuid();
        }

        public Employee(object guid)
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
