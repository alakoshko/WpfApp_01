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

        public ObservableCollection<Department> Depts { get; } = new ObservableCollection<Department>();
        public ObservableCollection<Employee> Employes { get; } = new ObservableCollection<Employee>();
        //public ObservableCollection<Employee> Employes { get; } = new ObservableCollection<Employee>
        //{
        //    new Employee{ Name = "Иван", Lastname = "Петров", Dept = new Department{ DeptName = "FronOffice"} },
        //    new Employee{ Name = "Петр", Lastname = "Иванов" },
        //    new Employee{ Name = "Василий", Lastname = "Сидоров" },
        //    new Employee{ Name = "Валерий", Lastname = "Ельченко" },
        //    new Employee{ Name = "Феофан", Lastname = "Шайн" },
        //    new Employee{ Name = "Игнат", Lastname = "Черкашин" },
        //    new Employee{ Name = "Якуб", Lastname = "Малиновский" },
        //};
        private Employee _SelectedEmployer;
        public Employee SelectedEmployer
        {
            get { return _SelectedEmployer; }
            set => Set(ref _SelectedEmployer, value);
        }

        public ObservableCollection<Company> Companies { get; } = new ObservableCollection<Company>();
        

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand SaveEmployeeCommand { get; }

        private LambdaCommand addCommandEmployee;
        public LambdaCommand AddCommandEmployee
        {
            get
            {
                return addCommandEmployee ??
                    (addCommandEmployee = new LambdaCommand(obj =>
                    {
                        Employee emp = new Employee();
                        Employes.Insert(0, emp);
                        SelectedEmployer = emp;
                    }));
            }
        }

        internal SQLProcessing sqlProcessing;

        public MainWindowViewModel()
        {
            AddCommand = new LambdaCommand(OnAddCommandExecute);
            RemoveCommand = new LambdaCommand(OnRemoveCommandExecute);
            EditCommand = new LambdaCommand(OnEditCommandExecute);
            SaveEmployeeCommand = new LambdaCommand(OnSaveEmployeeCommandExecute);

            #region Загрузка из БД
            sqlProcessing = new SQLProcessing();

            //Company
            sqlProcessing.GetCompanies(Companies);

            //Departaments
            sqlProcessing.GetDepartments(Depts);
            foreach (var v in Depts)
            {
                if (v.CompanyID != null)
                    v.Company = Companies.FirstOrDefault(p => p.ID == v.CompanyID);
            }
            

            //Employes
            sqlProcessing.GetEmployees(Employes);
            foreach (var v in Employes)
            {
                if (v.DeptID != null)
                    v.Dept = Depts.FirstOrDefault(p => p.ID == v.DeptID);
            }
            SelectedEmployer = null;

            #endregion
        }


           

        private void OnAddCommandExecute(object obj)
        {
            //MessageBox.Show("Команда редактирования");

            var employersEditor = new EmployerEdit(obj as Employee);
            employersEditor.Title = $"Редактор карточки работника";
            var dialogResult = employersEditor.ShowDialog();
            if (dialogResult is true)
            {
                var empID = sqlProcessing.AddEmployee(obj as Employee);
            }
        }

        private void OnRemoveCommandExecute(object obj)
        {
            //MessageBox.Show("Команда удаления");
            if (obj != null)
            {
                var emp = Employes.FirstOrDefault(p => p.ID == (obj as Employee).ID);
                if (emp != null)
                    Employes.Remove(emp);
            }
            else { MessageBox.Show("Команда удаления не будет обработана"); }
        }

        private void OnEditCommandExecute(object obj)
        {
            //MessageBox.Show("Команда редактирования");
            if (obj != null)
            {
                //SelectedEmployer = obj as Employee;
                var employersEditor = new EmployerEdit(SelectedEmployer);
                employersEditor.Title = $"Редактор карточки работника";
                var dialogResult = employersEditor.ShowDialog();
                if(dialogResult is true)
                    OnSaveEmployeeCommandExecute(obj);
            }
        }

        private void OnSaveEmployeeCommandExecute(object obj)
        {
            //MessageBox.Show("Команда сохранения");
            if (obj != null)
            {
                //Employes = obj;
                sqlProcessing.UpdEmployee(obj as Employee);
            }

        }
    }
}
