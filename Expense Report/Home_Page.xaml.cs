using Expense_Report.Models;
using Microsoft.EntityFrameworkCore;
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

        public List<string> Names { get; set; } = new List<string>();
        public Home_Page()
        {
            InitializeComponent();
            GetName();
            this.DataContext = this;
        }

        private void Select_button_Click(object sender, RoutedEventArgs e)
        {
            string name = List_Box.SelectedItem.ToString();
            NavigationService.Navigate(new Report(name));
        }

        private void GetName()
        {
            ExpenseContext db = new ExpenseContext();

            Names = db.ExpenseReports.Select(x => x.Name).Distinct().ToList();
        }

    }
}
