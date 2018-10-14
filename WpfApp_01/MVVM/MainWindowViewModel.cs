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
        //{
        //    new Department("FrontOffice"){ DeptName = "FrontOffice" },
        //    new Department{ DeptName = "BackOffice" }
        //};

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


        public ObservableCollection<Company> Companies { get; } = new ObservableCollection<Company>();
        //{
        //    new Company{ Name = "Sun microsystem" }
        //};

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand SaveEmployeeCommand { get; }

        public MainWindowViewModel()
        {
            AddCommand = new LambdaCommand(OnAddCommandExecute);
            RemoveCommand = new LambdaCommand(OnRemoveCommandExecute);
            EditCommand = new LambdaCommand(OnEditCommandExecute);
            SaveEmployeeCommand = new LambdaCommand(OnSaveEmployeeCommandExecute);

            #region Загрузка из БД
            var sqlProcessing = new SQLProcessing();

            //Company
            sqlProcessing.GetCompanies(Companies);

            //Departaments
            sqlProcessing.GetDepartments(Depts);
            foreach (var v in Depts)
            {
                if (v.CompanyID != null)
                    v.Company = GetCompanyByGuid(v.CompanyID);
            }

            //Employes
            sqlProcessing.GetEmployees(Employes);
            foreach(var v in Employes)
            {
                if(v.DeptID != null)
                    v.Dept = GetDepartamentByGuid(v.DeptID);
            }
            #endregion
        }

        private Company GetCompanyByGuid(Guid guid)
        {
            foreach (var v in Companies)
                if (v.ID == guid)
                    return v;

            return null;
        }

        private Department GetDepartamentByGuid(Guid guid)
        {
            foreach (var v in Depts)
                if (v.ID == guid)
                    return v;

            return null;
        }

        private void OnAddCommandExecute(object obj)
        {
            //MessageBox.Show("Команда редактирования");

            var employersEditor = new EmployerEdit(Employes);
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
                //Это не эффективно, но на поиски решений времени нет
                foreach (var v in Employes)
                    if (v.ID.ToString() == obj.ToString())
                    {
                        var employersEditor = new EmployerEdit(Employes, v);
                        employersEditor.Title = $"Редактор карточки работника";
                        employersEditor.ShowDialog();
                        break;
                    }
            }
            
        }

        private void OnSaveEmployeeCommandExecute(object obj)
        {
            MessageBox.Show("Команда сохранения");
            if (obj != null)
            {
                //Employes = obj;
            }

        }
    }
}
