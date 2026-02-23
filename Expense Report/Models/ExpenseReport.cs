using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Expense_Report.Models;

[Table("expense_report")]
[Index("Name", Name = "IX_expense_report_Name")]
public partial class ExpenseReport
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string Department { get; set; } = null!;

    [StringLength(200)]
    public string ExpenseTitle { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Amount { get; set; }

    public DateOnly ExpenseDate { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }
}
