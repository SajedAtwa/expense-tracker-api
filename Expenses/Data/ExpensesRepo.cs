using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Models;

namespace ExpenseTracker.Data
{
    public class ExpensesRepo : IExpensesRepo
    {
        private readonly ExpenseTrackerContext _context;

        public ExpensesRepo(ExpenseTrackerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
            => await _context.Expenses.ToListAsync();

        public async Task<Expense?> GetExpenseByIdAsync(int id)
            => await _context.Expenses.FindAsync(id);

        public async Task CreateExpenseAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void DeleteExpense(Expense expense)
        {
            _context.Expenses.Remove(expense);
        }
    }
}
