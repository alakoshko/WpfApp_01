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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class DepartmentEditor : Window
    {
        private Department dept;
        public DepartmentEditor()
        {
            InitializeComponent();
            lstViewDepts.ItemsSource = MainWindow.Depts;
            cmbCompany.ItemsSource = MainWindow.Companys;
        }


        private void lstViewDepts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dept = (Department)lstViewDepts.SelectedItem;
            Name.Text = dept.Name;
            //почему-то не работает...
            //cmbCompany.SelectedItem = dept.Company;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Depts.Add(new Department("новый департамент"));
            CollectionViewSource.GetDefaultView(lstViewDepts.ItemsSource).Refresh();
        }

        private void btnSaveDept_Click(object sender, RoutedEventArgs e)
        {
            if (dept != null)
            {
                dept.Name = Name.Text;
                //dept.Company = (Company)cmbCompany.SelectedItem;
                CollectionViewSource.GetDefaultView(lstViewDepts.ItemsSource).Refresh();
                CollectionViewSource.GetDefaultView(cmbCompany.ItemsSource).Refresh();
            }
        }
    }
}
