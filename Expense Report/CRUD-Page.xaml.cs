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
    /// Interaction logic for CRUD_Page.xaml
    /// </summary>
    public partial class CRUD_Page : Page
    {
        ExpenseContext db = new ExpenseContext();
        public CRUD_Page()
        {
            InitializeComponent();
            Refresh(new object(), new RoutedEventArgs());
        }

        private void addNewReport(object sender, RoutedEventArgs e)
        {
            ExpenseReport expenseReport = new ExpenseReport()
            {
                Name = Name.Text,
                Department = Departement.Text,
                Amount = decimal.Parse(Amount.Text),
                ExpenseTitle = ExpenseType.Text,
                ExpenseDate = new DateOnly()
            };

            db.ExpenseReports.Add(expenseReport);
            db.SaveChanges();
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            Grid_Data.ItemsSource = db.ExpenseReports.ToList();
        }

        private void deleteReport(object sender, RoutedEventArgs e)
        {
            db.Remove(db.ExpenseReports.FirstOrDefault(e => e.Id == int.Parse(Id.Text)));
            db.SaveChanges();
        }

        private void updateReport(object sender, RoutedEventArgs e)
        {

            var report = db.ExpenseReports.FirstOrDefault(e => e.Id == int.Parse(Id.Text));

            if(report != null)
            {
                report.Amount = decimal.TryParse(Amount.Text, out var value) ? decimal.Parse(Amount.Text) : report.Amount;
                report.Name = string.IsNullOrWhiteSpace(Name.Text) ? report.Name : Name.Text;
                report.ExpenseTitle = string.IsNullOrWhiteSpace(ExpenseType.Text) ? report.ExpenseTitle : ExpenseType.Text;
                report.Department = string.IsNullOrWhiteSpace(Departement.Text) ? report.Department : Departement.Text;
            }



            //var report = (ExpenseReport)Grid_Data.SelectedItem;

            //report.Amount = decimal.TryParse(Amount.Text, out var value) ? decimal.Parse(Amount.Text) : report.Amount;
            //report.Name = string.IsNullOrWhiteSpace(Name.Text) ? report.Name : Name.Text;
            //report.ExpenseTitle = string.IsNullOrWhiteSpace(ExpenseType.Text) ? report.ExpenseTitle : ExpenseType.Text;
            //report.Department = string.IsNullOrWhiteSpace(Departement.Text) ? report.Department : Departement.Text;

            db.SaveChanges();
        }

        private void searchById(object sender, RoutedEventArgs e)
        {
            var report = db.ExpenseReports.Where(e => e.Id == int.Parse(Id.Text)).ToList();
            Grid_Data.ItemsSource = report;
        }

    }
}


