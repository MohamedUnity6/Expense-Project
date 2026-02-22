using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Expense_Report
{
    public class Person : RoutedEventArgs
    {
        public Person()
        {

        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Address {  get; set; }
        public string Number {  get; set; }
    }
}
