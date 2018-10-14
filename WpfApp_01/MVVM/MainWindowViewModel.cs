using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfApp_01.DataManagement;

namespace WpfApp_01
{
    class MainWindowViewModel : ViewModel
    {

        public ObservableCollection<Department> Depts { get; } = new ObservableCollection<Department>
        {
            new Department("FrontOffice"){ DeptName = "FrontOffice" },
            new Department{ DeptName = "BackOffice" }
        };

        public ObservableCollection<Employee> Employes { get; } = new ObservableCollection<Employee>
        {
            new Employee{ Name = "Иван", Lastname = "Петров", Dept = new Department{ DeptName = "FronOffice"} },
            new Employee{ Name = "Петр", Lastname = "Иванов" },
            new Employee{ Name = "Василий", Lastname = "Сидоров" },
            new Employee{ Name = "Валерий", Lastname = "Ельченко" },
            new Employee{ Name = "Феофан", Lastname = "Шайн" },
            new Employee{ Name = "Игнат", Lastname = "Черкашин" },
            new Employee{ Name = "Якуб", Lastname = "Малиновский" },
        };

        
        public ObservableCollection<Company> Companies { get; } = new ObservableCollection<Company>
        {
            new Company{ Name = "Sun microsystem" }
        };

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand EditCommand { get; }

        public MainWindowViewModel()
        {
            AddCommand = new LambdaCommand(OnAddCommandExecute);
            RemoveCommand = new LambdaCommand(OnRemoveCommandExecute);
            EditCommand = new LambdaCommand(OnEditCommandExecute);

            var sqlProcessing = new SQLProcessing();
            //sqlProcessing.
        }

        private void OnAddCommandExecute(object obj)
        {
            //MessageBox.Show("Команда редактирования");

            var employersEditor = new EmployerEdit();
            employersEditor.Title = $"Редактор карточки работника";
            employersEditor.ShowDialog();
        }

        private void OnRemoveCommandExecute(object obj)
        {
            //MessageBox.Show("Команда удаления");
            if (obj != null)
            {
                foreach (var v in Employes)
                    if (v.ID.ToString() == obj.ToString())
                    {
                        Employes.Remove(v);
                        break;
                    }
            }
            else { MessageBox.Show("Команда удаления не будет обработана"); }
                        

        }

        private void OnEditCommandExecute(object obj)
        {
            //MessageBox.Show("Команда редактирования");
            if (obj != null)
            {
                foreach (var v in Employes)
                    if (v.ID.ToString() == obj.ToString())
                    {
                        var employersEditor = new EmployerEdit(v);
                        employersEditor.Title = $"Редактор карточки работника";
                        employersEditor.ShowDialog();
                        break;
                    }
            }
            
        }
    }
}
