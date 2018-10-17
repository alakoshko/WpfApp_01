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
using DataModel;

namespace WpfApp_01
{
    /// <summary>
    /// Логика взаимодействия для EmployerEdit.xaml
    /// </summary>
    public partial class EmployerEdit : Window
    {
        private ObservableCollection<Employee> _Employes;
        //private ObservableCollection<Department> _Depts;
        //private ObservableCollection<Company> _Companies;
        public Employee _SelectedEmployer;

        //public Employee employee;
        private bool newEmployee = false;


        public EmployerEdit(Employee employee)
        {
            InitializeComponent();
            _SelectedEmployer = employee;
            _Employes = (this.DataContext as MainWindowViewModel).Employes;
            //_Depts = (this.DataContext as MainWindowViewModel).Depts;
            //_Companies = (this.DataContext as MainWindowViewModel).Companies;

            if (_SelectedEmployer != null)
            {
                newEmployee = false;

                #region Employee fields
                ID.Content = _SelectedEmployer.ID;
                Lastname.Text = _SelectedEmployer.Lastname;
                Name.Text = _SelectedEmployer.Name;
                Patronymic.Text = _SelectedEmployer.Patronymic;
                Age.Text = _SelectedEmployer.Age.ToString();
                Dept.SelectedItem = _SelectedEmployer.Dept;
                Salary.Text = _SelectedEmployer.strSalary;
                Dept.ItemsSource = (this.DataContext as MainWindowViewModel).Depts;
                Dept.SelectedItem = _SelectedEmployer.Dept;
                #endregion
            }
        }
        
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _SelectedEmployer.Lastname = Lastname.Text;
            _SelectedEmployer.Name = Name.Text;
            _SelectedEmployer.Patronymic = Patronymic.Text;

            //_SelectedEmployer.Position = Position.SelectedItem.ToString();
            _SelectedEmployer.Salary = double.Parse(Salary.Text);
            _SelectedEmployer.Age = int.Parse(Age.Text);
            //_SelectedEmployer.Birthday = ;
            _SelectedEmployer.Dept = Dept.SelectedItem as Department;

            this.DialogResult = true;
            this.Close();
        }
    }
}
