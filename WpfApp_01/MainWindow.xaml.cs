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
using WpfApp_01.DataManagement;

namespace WpfApp_01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }


        private object objEmpToAdd;

        //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listViewPersonal.ItemsSource);
        //view.Filter = UserFilter;

        //private bool UserFilter(object item)
        //{
        //    if (String.IsNullOrEmpty(comboDepts.Text))
        //        return true;
        //    else
        //        //return ((item as Employee).Name.IndexOf(comboDepts.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        //        return (item as Employee).department.Name.IndexOf(comboDepts.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        //}


        //private void btnAddEmpl_Click(object sender, RoutedEventArgs e)
        //{
        //    //var employersEditor = new EmployerEdit();
        //    //employersEditor.Title = $"Редактор карточки работника";
        //    //employersEditor.ShowDialog();

        //    //CollectionViewSource.GetDefaultView(listViewPersonal.ItemsSource).Refresh();
        //}


        private void comboDepts_DropDownClosed(object sender, EventArgs e)
        {
            //CollectionViewSource.GetDefaultView(listViewPersonal.ItemsSource).Refresh();
        }

        private void listViewPersonal_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Show form Employers
            //var employersEditor = new EmployerEdit((Employee)listViewPersonal.SelectedItem);
            //employersEditor.Title = $"Редактор карточки работника";
            //employersEditor.ShowDialog();

            //CollectionViewSource.GetDefaultView(listViewPersonal.ItemsSource).Refresh();
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

        private void dtGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                //FrameworkElement element_EmpNo = dtGrid.Columns[0].GetCellContent(e.Row);
                //if (element_EmpNo.GetType() == typeof(TextBox))
                //{
                //    var eno = ((TextBox)element_EmpNo).Text;
                //    e.EmpNo = Convert.ToInt32(eno);
                //}
                //FrameworkElement element_EmpName = dtGrid.Columns[1].GetCellContent(e.Row);
                //if (element_EmpName.GetType() == typeof(TextBox))
                //{
                //    var ename = ((TextBox)element_EmpName).Text;
                //    objEmpToAdd.EmpName = ename;
                //}
                //FrameworkElement element_Salary = dtGrid.Columns[2].GetCellContent(e.Row);
                //if (element_Salary.GetType() == typeof(TextBox))
                //{
                //    var salary = ((TextBox)element_Salary).Text;
                //    objEmpToAdd.Salary = Convert.ToInt32(salary);
                //}
                //FrameworkElement element_DeptNo = dtGrid.Columns[3].GetCellContent(e.Row);
                //if (element_DeptNo.GetType() == typeof(TextBox))
                //{
                //    var dno = ((TextBox)element_DeptNo).Text;
                //    objEmpToAdd.DeptNo = Convert.ToInt32(dno);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InsertEmpoyee(object obj)
        {
            (DataContext as MainWindowViewModel).SelectedEmployer.ID = (DataContext as MainWindowViewModel).sqlProcessing.AddEmployee(obj as Employee);
            
        }

        private void dtGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {
                var Res = MessageBox.Show("Вы уверены что хотите добавить запись?", "Подтверждение", MessageBoxButton.YesNo);
                if (Res == MessageBoxResult.Yes)
                {
                    InsertEmpoyee((DataContext as MainWindowViewModel).SelectedEmployer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objEmpToAdd = dtGrid.SelectedItem as Employee;
        }
    }
}
