using AutoMapper;
using ExpenseTracker.Dtos;
using ExpenseTracker.Models;

namespace ExpenseTracker.Profiles
{
    public class ExpensesProfile : Profile
    {
        public ExpensesProfile()
        {
            // Entity -> Read DTO
            CreateMap<Expense, ExpenseReadDto>();

            // Create DTO -> Entity
            CreateMap<ExpenseCreateDto, Expense>();

            // Update DTO -> Entity
            CreateMap<ExpenseUpdateDto, Expense>();

            CreateMap<Expense, ExpenseUpdateDto>();
            CreateMap<ExpenseUpdateDto, Expense>();

        }
    }
}
