namespace ExpenseTracker.Dtos
{
    public class ExpenseReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTimeOffset Date { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
