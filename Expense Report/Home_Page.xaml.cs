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

namespace Expense_Report
{
    /// <summary>
    /// Interaction logic for Home_Page.xaml
    /// </summary>
    public partial class Home_Page : Page
    {
        public List<Employee> employees { get; set; } = new List<Employee>();
        public Home_Page()
        {
            InitializeComponent();
            saveEmployees();
            this.DataContext = this;
        }

        private void Select_button_Click(object sender, RoutedEventArgs e)
        {
            string name = List_Box.SelectedItem.ToString();
            NavigationService.Navigate(new Report(name));
        }

        private void saveEmployees()
        {
            employees.Add(new Employee() { Name = "Mohamed", Amount = 1000, Departement = "CS", ExpenseType = "UnKnown" });
            employees.Add(new Employee() { Name = "Ali", Amount = 1300, Departement = "IT", ExpenseType = "UnKnown" });
            employees.Add(new Employee() { Name = "Sabri", Amount = 1500, Departement = "ES", ExpenseType = "UnKnown" });
            employees.Add(new Employee() { Name = "Hanafy", Amount = 900, Departement = "IS", ExpenseType = "UnKnown" });
        }

    }
}
