using Expense_Report.Models;
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
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Page
    {
        
        public Report(string name)
        {
            InitializeComponent();
            ShowExpenseReports(name);
        }

        private void ShowExpenseReports(string name)
        {

            Name.Text = name;

            ExpenseContext db = new ExpenseContext();

            ReportList.ItemsSource = db.ExpenseReports.Where(e => e.Name == name).ToList();

            Departement.Text = db.ExpenseReports.Where(e => e.Name == name).Select(e => e.Department).FirstOrDefault();
        }



    }
}
