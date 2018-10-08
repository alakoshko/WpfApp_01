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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Company companySun = new Company("Sun");

        public static List<Employee> Personal;
        public static List<Department> Depts;
        public static List<Company> Companys;
        //public static Dictionary<Guid, Employee> dictEmplotyeers;

        public MainWindow()
        {
            InitializeComponent();

            Companys = new List<Company>();
            Companys.Add(new Company { Name = "Sun" } );
            

            var depts = new Department[]
            {
                new Department{ Name = "FrontOffice"},
                new Department{ Name = "BackOffice"}
            };

            var emps = new Employee[]
            {
                new Employee{ Name = "Иван", Lastname = "Петров", department = depts[1] },
                new Employee{ Name = "Петр", Lastname = "Иванов", department = depts[1] },
                new Employee{ Name = "Василий", Lastname = "Сидоров", department = depts[1] },
                new Employee{ Name = "Валерий", Lastname = "Ельченко", department = depts[0] },
                new Employee{ Name = "Феофан", Lastname = "Шайн ", department = depts[0] },
                new Employee{ Name = "Игнат", Lastname = "Черкашин", department = depts[1] },
                new Employee{ Name = "Якуб", Lastname = "Малиновский", department = depts[0] }
            };

            Personal = new List<Employee>(emps);
            Depts = new List<Department>(depts);
            //dictEmplotyeers = new Dictionary<Guid, Employee>();

            

            //Инициализируем Dictionary
            //foreach (Employee v in Personal)
            //{
            //    dictEmplotyeers.Add(v.ID, v);

            //    //Инициализируем ListView
            //    //listViewPersonal.Items.Add(v.ToString());
            //    listViewPersonal.Items.Add(v);
            //}
            //listViewPersonal.DisplayMemberPath = "Name";
            //listViewPersonal.SelectedValuePath = "ID";
            listViewPersonal.ItemsSource = null;
            listViewPersonal.ItemsSource = Personal;
            //foreach (KeyValuePair<Guid, List<Employee>> pair in dictEmplotyeers)
            //    {
            //        Console.WriteLine($"Key={pair.Key} : {pair.Value.Count}");
            //    }
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listViewPersonal.ItemsSource);
            view.Filter = UserFilter;

            comboDepts.DisplayMemberPath = "Name";
            comboDepts.SelectedValuePath = "ID";
            comboDepts.ItemsSource = null;
            comboDepts.ItemsSource = Depts; // Set data source which has all items
            

            //foreach (var v in Depts)
            //    comboDepts.Items.Add(v.ToString());

        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(comboDepts.Text))
                return true;
            else
                //return ((item as Employee).Name.IndexOf(comboDepts.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                return ((item as Employee).department.Name.IndexOf(comboDepts.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void listViewPersonal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnAddEmpl_Click(object sender, RoutedEventArgs e)
        {
            var employersEditor = new EmployerEdit();
            employersEditor.Title = $"Редактор карточки работника";
            employersEditor.ShowDialog();

            CollectionViewSource.GetDefaultView(listViewPersonal.ItemsSource).Refresh();
        }


        private void comboDepts_DropDownClosed(object sender, EventArgs e)
        {
            CollectionViewSource.GetDefaultView(listViewPersonal.ItemsSource).Refresh();
        }

        private void listViewPersonal_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Show form Employers
            var employersEditor = new EmployerEdit((Employee)listViewPersonal.SelectedItem);
            employersEditor.Title = $"Редактор карточки работника";
            employersEditor.ShowDialog();

            CollectionViewSource.GetDefaultView(listViewPersonal.ItemsSource).Refresh();
        }

        private void btnEditDepts_Click(object sender, RoutedEventArgs e)
        {
            var deptsEditor = new DepartmentEditor();
            deptsEditor.ShowDialog();

            CollectionViewSource.GetDefaultView(comboDepts.ItemsSource).Refresh();
            CollectionViewSource.GetDefaultView(listViewPersonal.ItemsSource).Refresh();
        }
    }
}
