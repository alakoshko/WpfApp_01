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
    public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region поля класса
        private Guid _ID;
        public Guid ID
        {
            get { return _ID; }
            private set { }
        }

        private string name;
        public string Name {
            get => name;
            set => setMetod<string>(value, ref name, Name);
        }

        private string lastname;
        public string Lastname {
            get => lastname;
            set => setMetod<string>(value, ref lastname, Lastname);
        }

        private string patronymic;
        public string Patronymic { get => patronymic;
            set => setMetod<string>(value, ref patronymic, Patronymic);
        }

        private int age;
        public int Age { get => age;
            set => setMetod<int>(value, ref age, Age);
        }

        private double salary;
        public double Salary { get => salary;
            set => setMetod<double>(value, ref salary, Salary);
        }

        private string position;
        public string Position
        {
            get => position;
            set => setMetod<string>(value, ref position, Position);
        }

        private void setMetod<T>(T value, ref T v, T V)
        {
            if (Equals(v, value)) return;
            v = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(V)));
        }
        #endregion 

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
