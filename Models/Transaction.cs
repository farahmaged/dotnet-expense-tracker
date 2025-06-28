using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
        public int Amount { get; set; }

        [StringLength(75)]
        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped]
        public string CategoryTitleWithIcon =>
            Category is null ? "" : $"{Category.Icon} {Category.Title}";

        [NotMapped]
        public string FormattedAmount =>
            $"{(Category is null || Category.Type == "Expense" ? "- " : "+ ")}{Amount.ToString("C0")}";
    }
}
