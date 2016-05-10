using Splice.BusinessLogic.Interface;
using Splice.DomainObjects;
using Splice.DTO;
using Splice.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.BusinessLogic.Impl
{
    public class ExpenseHelper : IExpenseHelper
    {
        private Repository<Expense> _expenseRepo;
        private Repository<ExpenseItems> _expenseItemsRepo;

        public ExpenseHelper(Repository<Expense> expenseRepo, Repository<ExpenseItems> expenseItemsRepo)
        {
            _expenseRepo = expenseRepo;
            _expenseItemsRepo = expenseItemsRepo;
        }

        /// <summary>
        /// returns all expenses with their items
        /// </summary>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        public ExpenseWithItems GetExpenseWithItems(int expenseId)
        {
            var expense = _expenseRepo.GetById(expenseId);
            var expenseItems = _expenseItemsRepo.FetchAll(x => x.ExpenseId == expenseId);

            var expenseWithItems = new ExpenseWithItems
            {
                ExpenseId = expense.Id,
                ExpenseTitle = expense.Title,
                DateCreated = expense.DateCreated,
                ExpenseItems = expenseItems
            };
            return expenseWithItems;
        }

        /// <summary>
        /// create a new expense
        /// </summary>
        /// <param name="expense"></param>
        public void CreateNewExpense(Expense expense)
        {
            _expenseRepo.Save(expense);
        }

        /// <summary>
        ///Adds items to a newly created expense
        /// </summary>
        /// <param name="expenseId"></param>
        /// <param name="items"></param>
        public void AddItemsToExpense(int expenseId, List<ExpenseItems> items)
        {
            foreach (var item in items)
            {
                item.ExpenseId = expenseId;
                _expenseItemsRepo.Save(item);
            }
        }

        /// <summary>
        /// removes an expense with the associated item
        /// </summary>
        /// <param name="expenseId"></param>
        /// <returns></returns>
        public bool RemoveExpense(int expenseId)
        {
            var expense = _expenseRepo.GetById(expenseId);
            if (expense != null)
            {
                _expenseRepo.Delete(expenseId);
                _expenseItemsRepo.Delete(x => x.ExpenseId == expenseId);
                return true;
            }
            return false;
        }

        /// <summary>
        ///removes a single item from an expense
        /// </summary>
        /// <param name="itemId"></param>
        public void RemoveItemFromExpense(int itemId)
        {
            _expenseItemsRepo.Delete(itemId);
        }
    }
}
