using System;
using System.Collections.Generic;
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

namespace WpfApp_01
{
    /// <summary>
    /// Логика взаимодействия для EmployerEdit.xaml
    /// </summary>
    public partial class EmployerEdit : Window
    {
        private Employee employee;
        private bool newEmployee = false;

        public EmployerEdit() {
            InitializeComponent();
            Init();
            employee = new Employee();
            newEmployee = true;
        }

        public EmployerEdit(Employee employee)
        {
            InitializeComponent();
            Init();
            this.employee = employee;
            if (employee != null)
            {
                Lastname.Text = employee.Lastname;
                Firstname.Text = employee.Name;
                Patronymic.Text = employee.Patronymic;
                Dept.SelectedItem = employee.department; // It will make it as a selected item

                newEmployee = false;
            }
        }

        private void Init()
        {
            //Dept.DisplayMemberPath = "Name";
            //Dept.SelectedValuePath = "ID";
            Dept.ItemsSource = null;
            //Dept.ItemsSource = MainWindow.Depts; // Set data source which has all items
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        { 
            employee.Lastname = Lastname.Text;
            employee.Name = Firstname.Text;
            employee.Patronymic = Patronymic.Text;
            employee.department = (Department)Dept.SelectedItem;

            //if (newEmployee)
            //    MainWindow.Personal.Add(employee);
   
            this.Close();
        }
    }
}
