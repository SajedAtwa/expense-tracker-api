using ExpenseTracker.Models;

namespace ExpenseTracker.Data
{
    public interface IExpensesRepo
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task<Expense?> GetExpenseByIdAsync(int id);

        Task CreateExpenseAsync(Expense expense);
        Task<bool> SaveChangesAsync();
        void DeleteExpense(Expense expense);

    }
}
