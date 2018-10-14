using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp_01.DataManagement;

namespace WpfApp_01
{
    /// <summary>
    /// Логика взаимодействия для EmployerEdit.xaml
    /// </summary>
    public partial class EmployerEdit : Window
    {
        private ObservableCollection<Employee> Employes { get; }
        public Employee employee;
        private bool newEmployee = false;

        public EmployerEdit(ObservableCollection<Employee> employes) {
            InitializeComponent();
            //Init();
            Employes = employes;
            employee = new Employee();
            newEmployee = true;
        }

        public EmployerEdit(ObservableCollection<Employee> employes, Employee emp)
        {
            InitializeComponent();
            //Init();
            this.employee = emp;
            if (emp != null)
            {
                newEmployee = false;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        { 
            //employee.Lastname = Lastname.Text;
            //employee.Name = Name.Text;
            //employee.Patronymic = Patronymic.Text;
            ////employee.Position = "";
            ////employee.Salary = 100;
            ////employee.Age = ;
            ////employee.Birthday = ;
            ////employee.Dept = ;
            ////employee.department = (Department)Dept.SelectedItem;

            //if (newEmployee)
            //{
            //    var sqlProcessing = new SQLProcessing();
            //    employee.ID = sqlProcessing.AddEmployee(employee);

            //    Employes.Add(employee);
            //}
            //else
            //{

            //}

            this.Close();
        }
    }
}
