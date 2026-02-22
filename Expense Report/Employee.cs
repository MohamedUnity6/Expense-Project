using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Report
{
    public class Employee
    {
        public string Name {  get; set; }

        public string Departement {  get; set; }
        public int Amount { get; set; }
        public string ExpenseType {  get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
