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

        private List<Company> Companys;

        public MainWindow()
        {
            InitializeComponent();

            Companys = new List<Company>();
            Companys.Add(new Company { Name = "Sun" });

            Companys[0].Departments.Append(new Department { Name = "FrontOffice" });
            Companys[0].Departments.Append(new Department { Name = "BackOffice" });


            comboDepts.ItemsSource = Companys[0].Departments;

        }


        //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listViewPersonal.ItemsSource);
        //view.Filter = UserFilter;

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(comboDepts.Text))
                return true;
            else
                //return ((item as Employee).Name.IndexOf(comboDepts.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                return (item as Employee).department.Name.IndexOf(comboDepts.Text, StringComparison.OrdinalIgnoreCase) >= 0;
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
            //CollectionViewSource.GetDefaultView(listViewPersonal.ItemsSource).Refresh();
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
            //var deptsEditor = new DepartmentEditor();
            //deptsEditor.ShowDialog();

            //CollectionViewSource.GetDefaultView(comboDepts.ItemsSource).Refresh();
            //CollectionViewSource.GetDefaultView(listViewPersonal.ItemsSource).Refresh();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
