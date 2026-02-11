using AutoMapper;
using ExpenseTracker.Data;
using ExpenseTracker.Dtos;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;


namespace ExpenseTracker.Controllers
{
    [Route("api/expenses")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesRepo _repository;
        private readonly IMapper _mapper;

        public ExpensesController(IExpensesRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseReadDto>>> GetAllExpenses()
        {
            var expenses = await _repository.GetAllExpensesAsync();
            return Ok(_mapper.Map<IEnumerable<ExpenseReadDto>>(expenses));
        }

        [HttpGet("{id}", Name = "GetExpenseById")]
        public async Task<ActionResult<ExpenseReadDto>> GetExpenseById(int id)
        {
            var expense = await _repository.GetExpenseByIdAsync(id);
            if (expense == null) return NotFound();

            return Ok(_mapper.Map<ExpenseReadDto>(expense));
        }

        [HttpPost]
        public async Task<ActionResult<ExpenseReadDto>> CreateExpense(ExpenseCreateDto createDto)
        {
            var expenseModel = _mapper.Map<Expense>(createDto);

            await _repository.CreateExpenseAsync(expenseModel);
            await _repository.SaveChangesAsync();

            var readDto = _mapper.Map<ExpenseReadDto>(expenseModel);

            return CreatedAtRoute(
                nameof(GetExpenseById),
                new { id = readDto.Id },
                readDto
            );
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExpense(int id, ExpenseUpdateDto updateDto)
        {
            var expenseFromDb = await _repository.GetExpenseByIdAsync(id);
            if (expenseFromDb == null) return NotFound();

            // Copy fields from DTO -> tracked entity
            _mapper.Map(updateDto, expenseFromDb);

            await _repository.SaveChangesAsync();
            return NoContent(); // 204
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialExpenseUpdate(
            int id,
            JsonPatchDocument<ExpenseUpdateDto> patchDoc)
        {
            if (patchDoc == null) return BadRequest();

            var expenseFromDb = await _repository.GetExpenseByIdAsync(id);
            if (expenseFromDb == null) return NotFound();

            // Map entity -> update DTO (what we patch)
            var expenseToPatch = _mapper.Map<ExpenseUpdateDto>(expenseFromDb);

            // Apply patch operations to DTO
            patchDoc.ApplyTo(expenseToPatch, ModelState);

            if (!TryValidateModel(expenseToPatch))
                return ValidationProblem(ModelState);

            // Map patched DTO -> entity (tracked)
            _mapper.Map(expenseToPatch, expenseFromDb);

            await _repository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExpense(int id)
        {
            var expenseFromDb = await _repository.GetExpenseByIdAsync(id);
            if (expenseFromDb == null) return NotFound();

            _repository.DeleteExpense(expenseFromDb);
            await _repository.SaveChangesAsync();

            return NoContent();
        }





    }
}
