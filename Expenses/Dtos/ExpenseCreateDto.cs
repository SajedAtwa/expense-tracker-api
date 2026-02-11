using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Dtos
{
    public class ExpenseCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = string.Empty; // "Expense" / "Income"

        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;

        [MaxLength(500)]
        public string? Notes { get; set; }
    }
}
