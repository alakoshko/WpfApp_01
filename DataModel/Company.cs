using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Company : ViewModel
    {
        private Guid _ID;
        public Guid ID
        {
            get { return _ID; }
            set => Set(ref _ID, value);
        }

        private string name;
        public string Name
        {
            get => name;
            set => Set(ref name, value);
        }

        public Company() => Name = "";

        public Company(string name) => Name = name;


        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
